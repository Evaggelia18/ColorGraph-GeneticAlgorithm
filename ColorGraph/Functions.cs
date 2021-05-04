using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorGraph
{
    class Functions
    {
        int grade;
        List<List<int>> col;

        public Functions( int grade, List<List<int>> col )
        {
            grade = grade;
            col = col;
        }

        public List<Functions> Population(int num)
        {
            List<List<int>> population = new List<List<int>>();
            List<Functions> solutions = new List<Functions>();
            //Αρχικός πληθυσμός : 10

            Random rn;
            for (int i = 0; i<=9; i++)
            {
                if (num == 0) { break; }
                for (int j = 0; j<= 10; j++)
                {
                    if (num == 0) { break; }
                    List<int> columns = new List<int>();
                    for (int k = 0; k <= 6; k++)
                    {
                        rn = new Random();
                        if( rn.Next(1, 6) == 6 )
                        {
                            columns[k] = 1;
                            num--;
                        }
                        else 
                        {
                            columns[k] = 0;
                        }
                        //Οταν συμπληρώνεται ο αριθμός τον κόμβων που θέλουμε να χρωματίσουμε σε ένα γράφο οι επαναλήψεις τελειώνουν
                        if(num==0) { break; }
                    }
                    population.Add(columns);
                }
                solutions.Add(new Functions(0, population));
            }

            return solutions;
        }

        

    }
}
