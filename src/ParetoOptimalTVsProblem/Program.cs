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

    /// <summary>
    /// The entry point for the application.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {
        // Initialize default values for the number of TVs and features
        var numberOfTVs = 10;
        var numberOfFeatures = 3;

        // Parse command-line arguments to override default values
        // -t for setting the number of TVs
        // -f for setting the number of features
        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-t" when i < args.Length - 1:
                    // Try to parse the next argument as the number of TVs
                    int.TryParse(args[i + 1], out numberOfTVs);
                    i++;  // Skip the next argument since we've processed it
                    break;
                case "-f" when i < args.Length - 1:
                    // Try to parse the next argument as the number of features
                    int.TryParse(args[i + 1], out numberOfFeatures);
                    i++;  // Skip the next argument since we've processed it
                    break;
            }
        }

        // Initialize dependency injection container using Autofac
        var builder = new ContainerBuilder();
        builder.RegisterType<DominanceChecker>().AsSelf();
        builder.RegisterType<TVGenerator>().AsSelf();
        builder.RegisterType<ParetoFinder>().AsSelf()
            .WithParameter(new TypedParameter(typeof(DominanceChecker), new DominanceChecker()));
        var container = builder.Build();

        // Begin dependency injection scope
        using var scope = container.BeginLifetimeScope();

        // Resolve dependencies
        var dominanceChecker = scope.Resolve<DominanceChecker>();
        var tvGenerator = scope.Resolve<TVGenerator>();
        var paretoFinder = scope.Resolve<ParetoFinder>();

        // Generate a list of random TVs based on the provided (or default) parameters
        var tvs = tvGenerator.GenerateRandomTVs(numberOfTVs, numberOfFeatures);

        // Display the original list of TVs
        Console.WriteLine("Original list of TVs:");
        foreach (var tv in tvs)
        {
            Console.WriteLine(string.Join(", ", tv.Features));
        }

        // Find and display the Pareto-optimal TVs from the original list
        var paretoOptimalTVs = paretoFinder.FindParetoOptimal(tvs);
        Console.WriteLine("Pareto-optimal TVs:");
        foreach (var tv in paretoOptimalTVs)
        {
            Console.WriteLine(string.Join(", ", tv.Features));
        }

    }

}
