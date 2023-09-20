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
using Autofac;
using ParetoOptimalTVsModel;
using ParetoOptimalTVsServices;

namespace ParetoOptimalTVsProblem;

public class Program
{
    static void Main(string[] args)
    {

        var builder = new ContainerBuilder();
        builder.RegisterType<DominanceChecker>().AsSelf();
        builder.RegisterType<TVGenerator>().AsSelf();
        builder.RegisterType<ParetoFinder>().AsSelf()
            .WithParameter(new TypedParameter(typeof(DominanceChecker), new DominanceChecker()));
        var container = builder.Build();

        using (var scope = container.BeginLifetimeScope())
        {
            var dominanceChecker = scope.Resolve<DominanceChecker>();
            var tvGenerator = scope.Resolve<TVGenerator>();
            var paretoFinder = scope.Resolve<ParetoFinder>();

            var tvs = tvGenerator.GenerateRandomTVs(10, 3);

            Console.WriteLine("Original list of TVs:");
            foreach (var tv in tvs)
            {
                Console.WriteLine(string.Join(", ", tv.Features));
            }

            var paretoOptimalTVs = paretoFinder.FindParetoOptimal(tvs);

            Console.WriteLine("Pareto-optimal TVs:");
            foreach (var tv in paretoOptimalTVs)
            {
                Console.WriteLine(string.Join(", ", tv.Features));
            }
        }

    }

}
