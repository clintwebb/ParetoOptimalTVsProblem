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

    /// <summary>
    /// Generates a list of TVs, each with a specified number of random features.
    /// </summary>
    /// <param name="numberOfTVs">The number of TVs to generate. Must be a non-negative integer.</param>
    /// <param name="numberOfFeatures">The number of features each TV should have. Must be a non-negative integer.</param>
    /// <returns>
    /// A list of <see cref="TV"/> instances with random features. 
    /// Each feature is an integer between 0 and 10 (inclusive).
    /// Returns an empty list if <paramref name="numberOfTVs"/> or <paramref name="numberOfFeatures"/> is zero.
    /// </returns>
    public List<TV> GenerateRandomTVs(int numberOfTVs, int numberOfFeatures)
    {
        var tvs = new List<TV>();

        // Validate that numberOfTVs and numberOfFeatures are greater than zero
        if (numberOfTVs <= 0 || numberOfFeatures <= 0)
        {
            return tvs;
        }

        var rng = new Random();

        for (var i = 0; i < numberOfTVs; i++)
        {
            var features = new List<int>();

            for (var j = 0; j < numberOfFeatures; j++)
            {
                // Generate a random integer between 0 and 10 (inclusive) for each feature
                features.Add(rng.Next(0, 11));
            }

            // Create a new TV with the generated features and add it to the list
            tvs.Add(new TV(features));
        }

        return tvs;
    }

}
