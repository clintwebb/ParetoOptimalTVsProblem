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
using ParetoOptimalTVsServices;

namespace ParetoOptimalTVsProblem;

public class Program
{
    static void Main(string[] args)
    {
        // 1. Generate a list of random TVs
        List<TV> tvs = TVGenerator.GenerateRandomTVs(10, 3);

        // 2. Find the Pareto-optimal set of TVs
        List<TV> paretoOptimalTVs = ParetoFinder.FindParetoOptimal(tvs);

        // 3. Output the Pareto-optimal TVs
        Console.WriteLine("Pareto-optimal TVs:");
        foreach (var tv in paretoOptimalTVs)
        {
            Console.WriteLine(string.Join(", ", tv.Features));
        }
    }

}
