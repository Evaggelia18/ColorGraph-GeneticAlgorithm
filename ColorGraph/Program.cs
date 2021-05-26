using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose between the Greek letter 'Π' and 'Τ' . ");
            string answer = Console.ReadLine();
            List<Functions> pop;
            while (!answer.Equals("EXIT"))
            {
                if (answer.Equals("P")) 
                { 
                    pop = Functions.Population(8);
                    Functions fn = Procedure.start_Procedure(pop, answer);
                    Print_Table(fn);
                }
                else if (answer.Equals("T")) 
                { 
                    pop = Functions.Population(6);
                    Functions fn = Procedure.start_Procedure(pop, answer);
                    Print_Table(fn);
                }
                Console.WriteLine("Choose between the Greek letter 'Π' and 'Τ' . ");
                Console.WriteLine("Type EXIT when you want to exit the program. ");
                answer = Console.ReadLine();
                
            }
           
            
        }

        public static void Print_Table(Functions solution)
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("|" + solution.col[i][0] + "|" + solution.col[i][1] + "|" + solution.col[i][2] + "|" + solution.col[i][3] + "|" + solution.col[i][4] + "|" + solution.col[i][5] + "|" + solution.col[i][6] + "|" + "\n");
            }
            Console.WriteLine(solution.grade);
        }


    }
}
