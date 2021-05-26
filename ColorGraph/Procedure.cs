using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorGraph
{
    class Procedure
    {
        public static Functions start_Procedure (List<Functions> population, string answer)
        {
            if (answer.Equals("P")) { population = Functions.Fitness_P(population); }
            else { population = Functions.Fitness_T(population); }
            for (int i = 0; i <= 9; i++)
            {
                if (population[i].grade >= 26 && answer.Equals("P"))
                {
                    return population[i];
                }
                else if (population[i].grade >= 14 && answer.Equals("T"))
                {
                    return population[i];
                }
                
            }

            while (true)
            {
                population = Functions.Create_Children(population);
                if (answer.Equals("P")) { population = Functions.Fitness_P(population); }
                else { population = Functions.Fitness_T(population); }

                for (int i = 0; i <= 9; i++)
                {
                    if (population[i].grade >= 26 && answer.Equals("P"))
                    {
                        return population[i];
                    }
                    else if (population[i].grade >= 14 && answer.Equals("T"))
                    {
                        return population[i];
                    }

                }//

            }

        }

    }//
}
