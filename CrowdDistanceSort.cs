using System;

namespace KnapsackGeneticAlgorithm{
    
    partial class Program{

        public class Couple{
                public Individual x;
                public double Distance;

                public Couple(Individual x, double Distance){
                    this.x = x;
                    this.Distance = Distance;
                }

            }

        partial class ExtensionMethods{
        
            public static List<Individual> CrowdDistanceSort(List<Individual> population){
                Individual? maxByValue = population.MaxBy(a => a.fitnessValue);
                Individual? minByValue = population.MinBy(a => a.fitnessValue);

                Individual? maxByTime = population.MaxBy(a => a.fitnessTime);
                Individual? minByTime = population.MinBy(a => a.fitnessTime);

                var timeDifference = maxByTime.fitnessTime - minByTime.fitnessTime;
                var valueDifference = maxByValue.fitnessValue -  minByValue.fitnessValue;

                var New = new List<Couple>();
                for (int i = 0; i < population.Count; ++ i){
                    if (population[i] == maxByValue) New.Add(new Couple(population[i], Inf));
                    else if (population[i] == minByTime) New.Add(new Couple(population[i], Inf));
                    else New.Add(new Couple(population[i], 0));
                }

                for (var i = 1; i < population.Count - 1; ++i){
                    New[i].Distance +=
                        (New[i + 1].x.fitnessValue - New[i - 1].x.fitnessValue) / valueDifference;
                    New[i].Distance +=
                        (New[i + 1].x.fitnessTime - New[i - 1].x.fitnessTime) / timeDifference;
                }

                New = New.OrderByDescending(a => a.Distance).ToList();

                List<Individual> Return = new List<Individual>();
                foreach (var i in New) Return.Add(i.x);

                return Return;
            }

        }

    }

}