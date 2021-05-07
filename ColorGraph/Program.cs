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
            if (answer.Equals('Π'))
            {
                pop = Functions.Population(14);
            }
            else
            {
                pop = Functions.Population(9);
            }

            Procedure.start_Procedure(pop, answer);
            
        }
    }
}
