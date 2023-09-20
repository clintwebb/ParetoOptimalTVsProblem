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

using System.Linq;
using Xunit;
using ParetoOptimalTVsModel;
using ParetoOptimalTVsServices;

namespace Testing.ParetoOptimalTVsServices;

public class TVGeneratorUnitTests
{
    [Fact]
    public void GenerateRandomTVs_ReturnsEmptyList_WhenZeroTVsOrFeatures()
    {
        // Arrange
        var generator = new TVGenerator();

        // Act
        var resultZeroTVs = generator.GenerateRandomTVs(0, 3);
        var resultZeroFeatures = generator.GenerateRandomTVs(3, 0);

        // Assert
        Assert.Empty(resultZeroTVs);
        Assert.Empty(resultZeroFeatures);
    }

    [Fact]
    public void GenerateRandomTVs_ReturnsCorrectNumberOfTVs()
    {
        // Arrange
        var generator = new TVGenerator();

        // Act
        var result = generator.GenerateRandomTVs(5, 3);

        // Assert
        Assert.Equal(5, result.Count);
    }

    [Fact]
    public void GenerateRandomTVs_ReturnsTVsWithCorrectNumberOfFeatures()
    {
        // Arrange
        var generator = new TVGenerator();

        // Act
        var result = generator.GenerateRandomTVs(5, 3);

        // Assert
        Assert.All(result, tv => Assert.Equal(3, tv.Features.Count));
    }

    [Fact]
    public void GenerateRandomTVs_ReturnsTVsWithFeatureValuesInRange()
    {
        // Arrange
        var generator = new TVGenerator();

        // Act
        var result = generator.GenerateRandomTVs(5, 3);

        // Assert
        Assert.All(result, tv => Assert.All(tv.Features, feature => Assert.InRange(feature, 0, 10)));
    }

    [Fact]
    public void GenerateRandomTVs_ShouldNotReturnNull()
    {
        // Arrange
        var generator = new TVGenerator();

        // Act
        var result = generator.GenerateRandomTVs(5, 3);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, tv => Assert.NotNull(tv));
    }

}
