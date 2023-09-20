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

namespace ParetoOptimalTVsModel;

/// <summary>
/// Represents a Television model with various features.
/// </summary>
/// <remarks>
/// Each feature is represented by an integer value. Higher values usually indicate better features.
/// </remarks>
public class TV
{
    /// <summary>
    /// Gets or sets the features of the Television model.
    /// </summary>
    /// <value>The features as a list of integers.</value>
    public List<int> Features { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TV"/> class.
    /// </summary>
    /// <param name="features">The features to initialize the TV with.</param>
    /// <remarks>
    /// If the provided feature list is null, an empty list will be used.
    /// </remarks>
    public TV(List<int> features)
    {
        Features = features ?? new List<int>();
    }

    /// <summary>
    /// Returns a string representation of the Television model's features.
    /// </summary>
    /// <returns>A comma-separated string of the TV's features.</returns>
    public override string ToString()
    {
        return string.Join(", ", Features);
    }

}
