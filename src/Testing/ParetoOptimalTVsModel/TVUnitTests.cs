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
using Xunit;
using ParetoOptimalTVsModel;

namespace Testing.ParetoOptimalTVsModel;

public class TVUnitTests
{

    [Fact]
    public void Constructor_Initializes_Features()
    {
        // Arrange
        var features = new List<int> { 1, 2, 3 };

        // Act
        var tv = new TV(features);

        // Assert
        Assert.Equal(features, tv.Features);
    }

    [Fact]
    public void Constructor_Initializes_EmptyList_When_Null()
    {
        // Arrange & Act
        var tv = new TV(null);

        // Assert
        Assert.NotNull(tv.Features);
        Assert.Empty(tv.Features);
    }

    [Fact]
    public void ToString_Returns_Correct_String()
    {
        // Arrange
        var features = new List<int> { 1, 2, 3 };
        var tv = new TV(features);

        // Act
        var result = tv.ToString();

        // Assert
        Assert.Equal("1, 2, 3", result);
    }

}
