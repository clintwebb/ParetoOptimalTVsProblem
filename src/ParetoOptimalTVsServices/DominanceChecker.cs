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
/// Provides methods to check if one TV dominates another based on their features.
/// </summary>
/// <remarks>
/// Dominance is defined as one TV having features that are as good as or better than another TV across all features.
/// </remarks>
public class DominanceChecker
{
    /// <summary>
    /// Checks if <paramref name="tv1"/> dominates <paramref name="tv2"/> based on their features.
    /// </summary>
    /// <param name="tv1">The first TV to compare.</param>
    /// <param name="tv2">The second TV to compare.</param>
    /// <returns>
    /// Returns <c>true</c> if <paramref name="tv1"/> dominates <paramref name="tv2"/>; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method assumes that both TVs have the same number of features.
    /// Additional checks or normalization might be needed depending on your specific use-case.
    /// </remarks>
    public bool DoesTVDominate(TV tv1, TV tv2)
    {
        return !tv1.Features.Where((t, i) => t < tv2.Features[i]).Any();
    }

}