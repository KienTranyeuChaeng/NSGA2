using System;

namespace KnapsackGeneticAlgorithm{
    
    partial class Program{

        partial class ExtensionMethods{

            // chọn Parents để lai
            public static List<Individual> selectParents(List<Individual> Population){
                //population.Sort((x, y) => x.fitness.CompareTo(y.fitness));

                List<Individual> newPopulation = new List<Individual>();
                while (Population.Count >= 2){
                    int pos = random.Next(Population.Count);
                    newPopulation.Add(Population[pos]);
                    Population.RemoveAt(pos);

                    pos = random.Next(Population.Count);
                    newPopulation.Add(Population[pos]);
                    Population.RemoveAt(pos);
                }

                if (Population.Count > 0) newPopulation.Add(Population[0]);

                return newPopulation;
            }

        }    

    }

}