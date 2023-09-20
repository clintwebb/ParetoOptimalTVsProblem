<p align="center">
  <h1 align="center">Pareto Optimal TVs Problem</h1>
</p>

## Problem Statement
Billy wishes to buy a television. He has characterised all the TVs on the 
market by giving each of them k feature scores between 0 and 10 (with 10 being a ‘better’ score 
than 0). TV A is said to ‘dominate’ TV B if it is as good or better than TV B across all scores. The 
‘pareto optimal’ subset of TVs are those TVs within the TVs on the market that are not 
dominated by any TV. 
1. Write a function to generate N random TVs. 
2. Write a function to check whether one TV dominates another. 
3. Write a function to find the pareto-optimal subset of TVs from a provided list. 
Bonus: What if comparing TV scores was computationally expensive?


To run this solution check it out locally then do the following 

```
dotnet restore
dotnet build
dotnet test 
```
Then to run it you can exexcute the program directly

```
C:\git\ParetoOptimalTVsProblem>.\src\ParetoOptimalTVsProblem\bin\Debug\net7.0\ParetoOptimalTVsProblem.exe
Original list of TVs:
1, 2, 7
0, 3, 8
6, 6, 2
7, 4, 8
0, 3, 9
2, 5, 8
5, 4, 3
4, 2, 9
7, 10, 4
7, 3, 0
Pareto-optimal TVs:
7, 4, 8
0, 3, 9
2, 5, 8
4, 2, 9
7, 10, 4
```

or you can pass in the number of TVs (-t) or the number of features (-f) or both.

```
C:\git\ParetoOptimalTVsProblem>.\src\ParetoOptimalTVsProblem\bin\Debug\net7.0\ParetoOptimalTVsProblem.exe -t 5 -f 2
Original list of TVs:
0, 1
3, 1
3, 6
2, 9
0, 4
Pareto-optimal TVs:
3, 6
2, 9
```

