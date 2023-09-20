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

public class TV
{

    public List<int> Features { get; set; }

    public TV(List<int> features)
    {
        Features = features ?? new List<int>();
    }

    // Optionally, you can add additional properties, methods or helper functions
    // e.g., ToString override for easier debugging or display.
    public override string ToString()
    {
        return string.Join(", ", Features);
    }

}
