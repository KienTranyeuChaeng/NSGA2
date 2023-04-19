using System;

namespace KnapsackGeneticAlgorithm{
    
    partial class Program{

        partial class ExtensionMethods{
            
            public static List<List<Individual>> NonDominatedSort(List<Individual> population){
                
                var frontList = new List<List<Individual>>();

                int[] cntDominated = new int[populationSize];
                List<List<int>> listDominate = new List<List<int>>();
                for (int i = 0; i < populationSize; ++ i) listDominate.Add(new List<int>());

                // tính số Dominate
                for (int i = 0; i < populationSize; ++ i){
                    for (int j = i; j < populationSize; ++ j){
                        if (Dominate(population[i], population[j]) == 1){
                            cntDominated[j] += 1;
                            listDominate[i].Add(j);
                        }

                        if (Dominate(population[i], population[j]) == -1){
                            cntDominated[i] += 1;
                            listDominate[j].Add(i);
                        }
                    }
                }

                bool running = true;
                while (running){
                    running = false;
                    List<int> Free = new List<int>();

                    for (int i = 0; i < populationSize; ++ i){
                        if (cntDominated[i] == 0){
                            running = true;

                            cntDominated[i] = -1;
                            Free.Add(i);

                        }
                    }

                    List<Individual> Add = new List<Individual>();
                    foreach (int i in Free){
                        Add.Add(population[i]);
                        
                        foreach (var j in listDominate[i]){
                            cntDominated[j] -= 1;
                        }
                    }

                    frontList.Add(Add);

                }

                return frontList;
            }

        }
 
    }

}