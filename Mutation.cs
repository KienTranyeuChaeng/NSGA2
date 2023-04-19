using System;

namespace KnapsackGeneticAlgorithm{
    
    partial class Program{

        partial class ExtensionMethods{

            // đột biến con
            public static List<Individual> Mutation(List<Individual> Childs){
                
                for (int i = 0; i < Childs.Count; ++ i){
                    for (int j = 0; j < geneSize; ++ j){
                        if (random.NextDouble() < mutationRate){
                            Childs[i].genes[j] = 1 - Childs[i].genes[j];
                        }
                    }
                }

                return Childs;
            }

        }    

    }

}