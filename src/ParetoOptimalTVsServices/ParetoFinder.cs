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

/// <summary>
/// Finds the Pareto-optimal subset of a given list of TVs based on their features.
/// </summary>
/// <remarks>
/// A TV is said to be 'Pareto-optimal' if it is not dominated by any other TV in the list.
/// A TV 'dominates' another if it is as good or better across all features.
/// </remarks>
public class ParetoFinder
{
    /// <summary>
    /// A helper service for checking feature dominance between two TVs.
    /// </summary>
    private readonly DominanceChecker _dominanceChecker;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParetoFinder"/> class.
    /// </summary>
    /// <param name="dominanceChecker">An instance of the <see cref="DominanceChecker"/> class.</param>
    public ParetoFinder(DominanceChecker dominanceChecker)
    {
        _dominanceChecker = dominanceChecker ?? throw new ArgumentNullException(nameof(dominanceChecker));
    }

    /// <summary>
    /// Finds and returns the Pareto-optimal subset of a list of TVs.
    /// </summary>
    /// <param name="tvs">The list of TVs to evaluate.</param>
    /// <returns>
    /// A list of TVs that are Pareto-optimal, i.e., not dominated by any other TV in the original list.
    /// Returns an empty list if the input list is empty or null.
    /// </returns>
    public List<TV> FindParetoOptimal(List<TV> tvs)
    {
        return (from tv1 in tvs let isDominated = tvs
            .Where(tv2 => tv1 != tv2)
            .Any(tv2 => _dominanceChecker.DoesTVDominate(tv2, tv1)) where !isDominated select tv1)
            .ToList();
    }
}
