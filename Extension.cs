using System;

namespace KnapsackGeneticAlgorithm{
    partial class Program{

        public class Individual{
            public int[] genes;
            public int fitness;
            public int fitnessValue;
            public int fitnessTime;

            public Individual(int[] bit){
                genes = bit;

                fitnessValue = 0;
                fitnessTime = 0;

                int sumWeight = 0;
                int sumFitness = 0;
                for(int i = 0; i < geneSize; ++ i){
                    sumWeight += bit[i] * weights[i];
                    sumFitness += bit[i] * values[i];
                    
                    fitnessValue += values[i];
                    fitnessTime += times[i];
                }

                fitness = sumWeight > maxWeight ? 0 : 1;
            }
        }
        
        partial class ExtensionMethods{
            
            // khởi tạo quần thể population
            public static List<Individual> Init(){
                List<Individual> population = new List<Individual>();

                for (int i = 0; i < populationSize; ++ i){
                    int[] bit = new int[geneSize];
                    for (int j = 0; j < geneSize; ++ j){
                        bit[j] = random.Next(2);
                    }

                    population.Add(new Individual(bit));
                }

                return population;
            } 

            public static int Dominate(Individual x, Individual y){

                if ((x.fitnessValue >= y.fitnessValue && x.fitnessTime <= y.fitnessTime) && 
                (x.fitnessValue > y.fitnessValue || x.fitnessTime < y.fitnessTime)) 
                    return 1;
                
                if ((y.fitnessValue >= x.fitnessValue && y.fitnessTime <= x.fitnessTime) && 
                (y.fitnessValue > x.fitnessValue || y.fitnessTime < x.fitnessTime)) 
                    return -1;

                return 0;
            }

        }
    }

}