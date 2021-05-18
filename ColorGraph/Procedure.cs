using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorGraph
{
    class Procedure
    {
        public static void start_Procedure (List<Functions> population, string answer)
        {
            if (answer.Equals('Π')) { population = Functions.Fitness_P(population); }
            else { population = Functions.Fitness_T(population); }

            while (Check_and_Print(population,answer) == false)
            {
                population = Functions.Create_Children(population);
                if (answer.Equals('Π')) { population = Functions.Fitness_P(population); }
                else { population = Functions.Fitness_T(population); }
            }



        }

        public static bool Check_and_Print(List<Functions> population, string answer)
        {
            for (int i=0; i<=9; i++)
            {
                if (population[i].grade >= 24 && answer.Equals('Π'))
                {
                    Print_Table(population[i]);
                    return true;
                }
                else if (population[i].grade >= 14 && answer.Equals('Τ'))
                {
                    Print_Table(population[i]);
                    return true;
                }
            }
            return false;
        }

        public static void Print_Table (Functions solution)
        {
            for (int i=0; i<=10; i++)
            {
                Console.WriteLine('|' +solution.col[i][0]+ '|' +solution.col[i][1]+ '|' +solution.col[i][2]+ '|' +solution.col[i][3]+ '|' +solution.col[i][4]+ '|' +solution.col[i][5]+ '|' +solution.col[i][6]+ '|' + '\n');
            }
        }


    }
}
