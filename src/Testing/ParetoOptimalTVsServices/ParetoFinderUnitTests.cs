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
using ParetoOptimalTVsServices;

namespace Testing.ParetoOptimalTVsServices;

public class ParetoFinderUnitTests
{

    [Fact]
    public void FindParetoOptimal_Returns_EmptyList_For_EmptyInput()
    {
        // Arrange
        var tvs = new List<TV>();
        var checker = new DominanceChecker();
        var finder = new ParetoFinder(checker);

        // Act
        var result = finder.FindParetoOptimal(tvs);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void FindParetoOptimal_Returns_SingleTV_For_SingleInput()
    {
        // Arrange
        var tv = new TV(new List<int> { 1, 1, 1 });
        var tvs = new List<TV> { tv };
        var checker = new DominanceChecker();
        var finder = new ParetoFinder(checker);

        // Act
        var result = finder.FindParetoOptimal(tvs);

        // Assert
        Assert.Single(result);
        Assert.Equal(tv, result[0]);
    }

    [Fact]
    public void FindParetoOptimal_Returns_AllTVs_When_AllAreOptimal()
    {
        // Arrange
        var tvs = new List<TV>
            {
                new TV(new List<int> { 1, 2, 3 }),
                new TV(new List<int> { 3, 2, 1 }),
                new TV(new List<int> { 2, 3, 1 }),
            };
        var checker = new DominanceChecker();
        var finder = new ParetoFinder(checker);

        // Act
        var result = finder.FindParetoOptimal(tvs);

        // Assert
        Assert.Equal(3, result.Count);
    }

    [Fact]
    public void FindParetoOptimal_Returns_ParetoOptimalTVs()
    {
        // Arrange
        var tvs = new List<TV>
            {
                new TV(new List<int> { 1, 1, 1 }),
                new TV(new List<int> { 2, 2, 2 }),
                new TV(new List<int> { 3, 3, 3 }),
            };
        var checker = new DominanceChecker();
        var finder = new ParetoFinder(checker);

        // Act
        var result = finder.FindParetoOptimal(tvs);

        // Assert
        Assert.Single(result);
        Assert.Equal(new List<int> { 3, 3, 3 }, result[0].Features);
    }

}
