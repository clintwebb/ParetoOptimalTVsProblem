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

public class DominanceChecker
{

    // Checks if tv1 dominates tv2
    public static bool DoesTVDominate(TV tv1, TV tv2)
    {
        // Assumes that both TVs have the same number of features for simplicity.
        // You might want to add additional checks or normalization here if needed.

        for (int i = 0; i < tv1.Features.Count; i++)
        {
            if (tv1.Features[i] < tv2.Features[i])
            {
                return false;
            }
        }

        return true;
    }

}
