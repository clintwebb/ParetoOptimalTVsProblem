#include <assert.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <getopt.h>

// To check known output, un-comment this.
// #define CHECK_TEST  1


#define DEF_TV          10
#define DEF_FEATURES    3

typedef struct __tv {
    int id;
    int *features;
    int feat_len;
    struct __tv * dominated;
} _tv;



_tv * generate_tv_list(int tv_limit, int feature_limit)
{
    assert(tv_limit > 0);
    assert(feature_limit > 0);

    _tv *list = calloc(tv_limit, sizeof(_tv));
    assert(list);

    for (int i=0; i<tv_limit; i++) {
        list[i].id = i;
        list[i].features = calloc(feature_limit, sizeof(int));
        assert(list[i].features);
        list[i].feat_len = feature_limit;
        list[i].dominated = NULL;

        for (int j=0; j<feature_limit; j++) {
            list[i].features[j] = rand() % 11;
            assert(list[i].features[j] >= 0 && list[i].features[j] <= 10);
        }
    }

    return(list);
}


// Will compare the features between 2 tv objects.
//   1 - will indicate aa 'dominates' over bb
//   0 - will indicate that it does not.

// we will make note in the object if a tv is dominated by another tv

int tv_compare(_tv *aa, _tv *bb)
{
    int result = -1;

    assert(aa);
    assert(bb);
    assert(aa->feat_len == bb->feat_len);

    assert(aa != bb);

#ifdef DEBUG
    printf("Comparing \n  #%d (", aa->id);
    for (int i=0; i<aa->feat_len; i++) {
        if (i>0) { printf(","); }
        printf("%d", aa->features[i]);
    }
    printf("), #%d (", bb->id);
    for (int i=0; i<bb->feat_len; i++) {
        if (i>0) { printf(","); }
        printf("%d", bb->features[i]);
    }
    printf(")\n");
#endif

    int dominated = 0;

    for (int i=0; i<aa->feat_len; i++) {
        if (aa->features[i] < bb->features[i]) {
            dominated = -1;
            i = aa->feat_len;   // break out of the loop
        }
    }

    if (dominated == 0) {
        // if we managed to get through the whole loop, then aa dominated bb, so we need to put a mark in the bb object to indicate it was dominated.
        // NOTE: if an object is dominated more than once, we only noting the last one
        bb->dominated = aa;
#ifdef DEBUG
        printf("AA dominated BB\n");
#endif
        return(1);
    }
    else {
#ifdef DEBUG
        printf("AA did NOT dominate BB\n");
#endif
        return(0);
    }
}



void main(int argc, char **argv)
{
    int g_tv = DEF_TV;
    int g_features = DEF_FEATURES;

    int c;   opterr = 0;
    while ((c = getopt(argc, argv, "t:f:")) != -1) {
        switch (c) {
            case 't':
                g_tv = atoi(optarg);
                assert(g_tv > 0);
                break;
            case 'f':
                g_features = atoi(optarg);
                assert(g_features > 0);
                break;
            default:
                fprintf(stderr, "Illegal argument \"%c\"\n", c);
                return;
        }
    }

    // Initialise the random number generator.
    time_t t;
    srand((unsigned) time(&t));


    // generate the list of TV's with random feature values within
    _tv *list = generate_tv_list(g_tv, g_features);


#ifdef CHECK_TEST
    // to compare against known data... we can insert that known data into the data...
    printf("KNOWN DATA\n\n");

    assert(g_tv == 10);
    assert(g_features == 3);

    int data[] = {
        1, 2, 7,
        0, 3, 8,
        6, 6, 2,
        7, 4, 8,
        0, 3, 9,
        2, 5, 8,
        5, 4, 3,
        4, 2, 9,
        7, 10, 4,
        7, 3, 0 };


    ///////////////////////////
    // IGNORE THE GENERATED LIST.... Add known data.
    int xx = 0;
    for (int i=0; i<g_tv; i++) {
        assert(list[i].features);
        for (int j=0; j<g_features; j++) {
            list[i].features[j] = data[xx];
            xx++;
        }
    }

#endif

    // print the list info.
    printf("Original List of TVs:\n");
    for (int i=0; i<g_tv; i++) {
        assert(list[i].features);
        for (int j=0; j<g_features; j++) {
            assert(list[i].features[j] >= 0 && list[i].features[j] <= 10);
            if (j > 0) { printf(", "); }
            printf("%d", list[i].features[j] );
        }
        printf("\n");
    }
    printf("\n");


    // go through the list comparing each one (not the most optimal)
    for (int i=0; i<g_tv; i++) {
        for (int j=0; j<g_tv; j++) {
            if (i != j) {
                tv_compare(&list[i], &list[j]);
            }
        }
    }

    // now print out the items that were not dominated.
    printf("Pareto-optimal TVs:\n");
    for (int i=0; i<g_tv; i++) {
        if (list[i].dominated == NULL) {
            for (int j=0; j<g_features; j++) {
                assert(list[i].features[j] >= 0 && list[i].features[j] <= 10);
                if (j > 0) { printf(", "); }
                printf("%d", list[i].features[j] );
            }
            printf("\n");
        }
    }

}
