using System;

namespace KnapsackGeneticAlgorithm{
    
    partial class Program{

        partial class ExtensionMethods{

            // lai tạo ra đời con
            public static List<Individual> crossover(List<Individual> Parents){
                List<Individual> Childs = new List<Individual>();

                for (int i = 0; i < Parents.Count; i += 2){
                    Individual[] Parent = {Parents[i], Parents[i + 1]};
                    int[] child0 = new int[geneSize];
                    int[] child1 = new int[geneSize];

                    int crossoverPoint = random.Next(geneSize);
                       
                    for (int j = 0; j < crossoverPoint; ++j){
                        child0[j] = Parent[0].genes[j];
                        child1[j] = Parent[1].genes[j];
                    }

                    for (int j = 0; j < geneSize; ++j){
                        child0[j] = Parents[1].genes[j];
                        child1[j] = Parents[0].genes[j];
                    }

                    Childs.Add(new Individual(child0));
                    Childs.Add(new Individual(child1));

                }

                return Childs;
            }

        }    

    }

}