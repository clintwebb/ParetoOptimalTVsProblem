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

using System;
using System.Collections.Generic;

using ParetoOptimalTVsModel;

namespace ParetoOptimalTVsServices;

public class TVGenerator
{

    // Generates N random TVs, each with k features
    public static List<TV> GenerateRandomTVs(int N, int k)
    {
        List<TV> tvs = new List<TV>();
        Random rng = new Random();

        for (int i = 0; i < N; i++)
        {
            List<int> features = new List<int>();

            for (int j = 0; j < k; j++)
            {
                features.Add(rng.Next(0, 11));  // Random integer between 0 and 10
            }

            tvs.Add(new TV(features));
        }

        return tvs;
    }

}
