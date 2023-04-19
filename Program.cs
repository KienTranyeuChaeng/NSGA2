using System;
using System.Collections.Generic;
using System.Diagnostics;
//using Extension;

namespace KnapsackGeneticAlgorithm{
    partial class Program{

        private const int NUM_THINGS = 100000;

        private static Random random = new Random();
        // Knapsack problem parameters
        private static int[] weights = new int[NUM_THINGS];
        private static int[] times = new int[NUM_THINGS];
        private static int[] values = new int[NUM_THINGS];

        private static int maxWeight = 80000;
        private static int geneSize = values.Length;

        // Genetic algorithm parameters
        private static int populationSize = 50;
        private static double mutationRate = 0.1;
        private static int eliteCount = 2;
        private static int maxGenerations = 300;

        private static double Inf = 1000000000;

        static void Main(string[] args){
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Generating data...");
            for (int i = 0; i < NUM_THINGS; ++i){
                weights[i] = random.Next(2) + 1;
                values[i] = random.Next(100);
                times[i] = random.Next(100);
            }

            Console.WriteLine("Solving...");
            sw.Start();
            // khởi tạo population
            List<Individual> population = ExtensionMethods.Init();

            //chạy thuật toán
            for (int generation = 0; generation < maxGenerations; generation++){
                
                // chọn parents
                List<Individual> Parents = ExtensionMethods.selectParents(population);

                // lai
                List<Individual> Childs = ExtensionMethods.crossover(Parents); 

                // đột biến con
                Childs = ExtensionMethods.Mutation(Childs);

                // merge cả parent cả con dựa trên fitness
                List<Individual> newPopulation = Childs;
                for (int i = 0; i < Parents.Count; ++ i) newPopulation.Add(Parents[i]);

                newPopulation = newPopulation.OrderByDescending(a => a.fitness).ToList();
                
                int pos = 0;
                for (int i = 0; i < newPopulation.Count; ++ i){
                    if (newPopulation[i].fitness == 0){
                        pos = i;
                        break;
                    }
                }

                newPopulation.Take(Math.Max(populationSize, pos + 1));

                // NonDominatedSort
                var NonDominatedSort = ExtensionMethods.NonDominatedSort(newPopulation);
                newPopulation.Clear();

                int layer = 0;
                int numIndividuals = 0;
                while (layer < NonDominatedSort.Count && numIndividuals + NonDominatedSort[layer].Count <= populationSize){
                    foreach (var i in NonDominatedSort[layer])
                        newPopulation.Add(i);

                    numIndividuals += NonDominatedSort[layer].Count;
                    layer += 1;
                }

                // CrowdDistanceSort


                population = newPopulation;
                population.Take(populationSize);
            }

            sw.Stop();
            /*
            foreach (Individual i in population)
            {
                Console.Write($"{i} ");
            }
            */
            Console.WriteLine();
            Console.WriteLine($"Exexution time: {sw.Elapsed}");
            Console.WriteLine(population.Max(c => c.fitness));
            Console.WriteLine($"{population[0].fitnessTime}  {population[0].fitnessValue}");

            //
        }
    }
}