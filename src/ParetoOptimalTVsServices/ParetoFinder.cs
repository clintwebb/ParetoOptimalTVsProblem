// Copyright 2023 Brian Gorrie
// 
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;

using ParetoOptimalTVsModel;

namespace ParetoOptimalTVsServices;

public class ParetoFinder
{
    public static List<TV> FindParetoOptimal(List<TV> tvs)
    {
        List<TV> paretoOptimalTVs = new List<TV>();

        // Loop over each TV in the original list
        foreach (TV tv1 in tvs)
        {
            bool isDominated = false;

            // Compare against all other TVs to check for dominance
            foreach (TV tv2 in tvs)
            {
                // Skip comparing the TV to itself
                if (tv1 == tv2) continue;

                // Check if tv1 is dominated by tv2
                if (DominanceChecker.DoesTVDominate(tv2, tv1))
                {
                    isDominated = true;
                    break;
                }
            }

            // If tv1 is not dominated by any other TV, add it to the Pareto-optimal list
            if (!isDominated)
            {
                paretoOptimalTVs.Add(tv1);
            }
        }

        return paretoOptimalTVs;
    }

}
