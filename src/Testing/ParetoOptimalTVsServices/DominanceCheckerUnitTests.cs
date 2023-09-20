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

using Xunit;
using ParetoOptimalTVsModel;
using ParetoOptimalTVsServices;
using System.Collections.Generic;

namespace Testing.ParetoOptimalTVsServices;

public class DominanceCheckerUnitTests
{
    [Fact]
    public void DoesTVDominate_Returns_True_When_Dominating()
    {
        // Arrange
        var tv1 = new TV(new List<int> { 5, 7, 9 });
        var tv2 = new TV(new List<int> { 3, 6, 8 });
        var checker = new DominanceChecker();

        // Act
        bool result = checker.DoesTVDominate(tv1, tv2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void DoesTVDominate_Returns_False_When_Not_Dominating()
    {
        // Arrange
        var tv1 = new TV(new List<int> { 3, 4, 5 });
        var tv2 = new TV(new List<int> { 4, 5, 6 });
        var checker = new DominanceChecker();

        // Act
        bool result = checker.DoesTVDominate(tv1, tv2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void DoesTVDominate_Returns_True_When_Features_Are_Equal()
    {
        // Arrange
        var tv1 = new TV(new List<int> { 5, 5, 5 });
        var tv2 = new TV(new List<int> { 5, 5, 5 });
        var checker = new DominanceChecker();

        // Act
        bool result = checker.DoesTVDominate(tv1, tv2);

        // Assert
        Assert.True(result);
    }

}
