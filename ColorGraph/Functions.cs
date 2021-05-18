using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorGraph
{
    class Functions
    {
        public int grade;
        public List<List<int>> col;

        public Functions( int grade, List<List<int>> col )
        {
            grade = grade;
            col = col;
        }

        public static List<Functions> Population(int num)
        {
            List<Functions> solutions = new List<Functions>();
            //Αρχικός πληθυσμός : 10

            Random rn;
            for (int i = 0; i<=9; i++)
            {
                List<List<int>> population = new List<List<int>>();
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

        //Η Mutation θα καλείται απο τη Create_Children
        public static List<Functions> Mutation(List<Functions> solutions)
        {
            Random rn = new Random();
            int num = rn.Next(2, 9);
            List<List<int>> population = new List<List<int>>();
            population = solutions[num].col;

            //Μεταλλάσουμε ένα τυχαίο κελί μιας τυχαίας λύσης από κάθε γενιά παιδιών.
            if (population[rn.Next(0, 10)][rn.Next(0, 6)] == 0) { population[rn.Next(0, 10)][rn.Next(0, 6)] = 1; }
            
            else { population[rn.Next(0, 10)][rn.Next(0, 6)] = 0; }

            solutions[num].col = population;
            return solutions;
        }
        
        // πληθυσμό 10
        // 2 παιδια --> επόμενη γενιά
        // 1 παιδι θα μεταλλάσεται
        // 8 αναπαράγονται μεταξύ τους
        public static List<Functions> Create_Children(List<Functions> previous_gen)
        {
            List<Functions> next_gen = new List<Functions>();
            Random rn = new Random();

            //Διατηρούμε 2 λύσεις από κάθε γενιά στην επόμενη χωρίς καμία αλλαγή 
            int num = rn.Next(0, 9);
            next_gen.Add(previous_gen[num]);
            previous_gen.RemoveAt(num);

            num = rn.Next(0, 8);
            next_gen.Add(previous_gen[num]);
            previous_gen.RemoveAt(num);

            for (int i=0; i<=7; i=i+2)
            {
                List<List<int>> children = new List<List<int>>();
                //1ο παιδί στήλες 0-5
                for (int k = 0; k<= 5; k++) { children.Add(previous_gen[i].col[k]); }
                
                // στήλες 6-10
                for (int k = 6; k <= 10; k++) { children.Add(previous_gen[i + 1].col[k]); }
                
                next_gen.Add(new Functions(0, children));
                children = new List<List<int>>();

                //2o παιδί στήλες 6-10
                for (int k = 6; k <= 10; k++) { children.Add(previous_gen[i].col[k]); }
                
                //στήλες 0-5
                for (int k = 0; k <= 5; k++) { children.Add(previous_gen[i + 1].col[k]); }
               
                next_gen.Add(new Functions(0, children));
            }
            next_gen = Mutation(next_gen);
            return next_gen;
        }

        public static List<Functions> Fitness_P(List<Functions> population)
        {
            int grade = 0;
            for (int i=0; i<=9; i++)
            {
                for (int k = 0; k<=10; k++)  //11 στήλες
                {
                    for (int j = 0; j<=6; j++)  // 7 γραμμές
                    {
                        //Ελεγχος για τη πρώτη στήλη της κάθε λύσης με διαφορετικές περιπτώσεις για τη πρώτη και τη τελευταία γράμμή
                        if ( k.Equals(0) && population[i].col[k][j] == 1)
                        {
                            if (j.Equals(0) && (population[i].col[k][j + 1] == 0 && population[i].col[k + 1][j] == 0) ) { grade = grade + 2; }
                            
                            else if (j.Equals(10) && (population[i].col[k][j - 1] == 0 && population[i].col[k + 1][j] == 0)) { grade = grade + 2; }
                           
                            else if (population[i].col[k][j + 1] == 0 && population[i].col[k + 1][j] == 0 && population[i].col[k][j - 1] == 0) { grade = grade + 2; }
                            
                        }
                        else if (k.Equals(10) && population[i].col[k][j] == 1)
                        {
                            if (j.Equals(0) && (population[i].col[k][j + 1] == 0 && population[i].col[k - 1][j] == 0)) { grade = grade + 2; }
                            
                            else if (j.Equals(10) && (population[i].col[k][j - 1] == 0 && population[i].col[k - 1][j] == 0) ) { grade = grade + 2; }
                            
                            else if (population[i].col[k][j + 1] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k][j - 1] == 0) { grade = grade + 2; }
                           
                        }
                        else if (k.Equals(1) || k.Equals(9) && population[i].col[k][j] == 1)
                        {
                            if (j.Equals(0) && (population[i].col[k + 1][j] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k][j + 1] == 0)) { grade++; }
                            
                            else if (j.Equals(10) && (population[i].col[k + 1][j] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k][j - 1] == 0)) { grade++; }
                            
                            else if (population[i].col[k + 1][j] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k][j - 1] == 0 && population[i].col[k][j + 1] == 0) { grade++; }
                        
                            if (j.Equals(0) && population[i].col[k][j] == 1)
                            {
                                if (k.Equals(0) && (population[i].col[k][j+1] == 0 && population[i].col[k +1][j] == 0) ) { grade = grade + 2; }
                                
                                else if (k.Equals(10) && (population[i].col[k][j + 1] == 0 && population[i].col[k - 1][j] == 0)) { grade = grade + 2; }
                                
                                else if (population[i].col[k][j + 1] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k + 1][j] == 0 ) { grade = grade + 2; }
                                
                            }
                            else if (j.Equals(1) && population[i].col[k][j] == 1)
                            {
                                if (k.Equals(0) && (population[i].col[k][j + 1] == 0 && population[i].col[k + 1][j] == 0 && population[i].col[k][j + 1] == 0)) { grade++; }
                               
                                else if (k.Equals(10) && (population[i].col[k][j + 1] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k][j + 1] == 0)) { grade++; }
                               
                                else if (population[i].col[k][j + 1] == 0 && population[i].col[k][j - 1] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k + 1][j] == 0) { grade++; }
                               
                            }
                            //
                        }
                    }
                }
                population[i].grade = grade;
                grade = 0;
            }
            return population;
        }


        public static List<Functions> Fitness_T(List<Functions> population)
        {
            int grade = 0;
            for (int i=0; i<=9; i++)
            {
                for (int k = 0; k <= 10; k++)
                {
                    for (int j=0; j<=6; j++)
                    {
                        if (j.Equals(0) && population[i].col[k][j] == 1)
                        {
                            if (k.Equals(0) && (population[i].col[k][j + 1] == 0 && population[i].col[k + 1][j] == 0)) { grade = grade + 2; }

                            else if (k.Equals(10) && (population[i].col[k][j + 1] == 0 && population[i].col[k - 1][j] == 0)) { grade = grade + 2; }
                           
                            else if (population[i].col[k][j + 1] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k + 1][j] == 0) { grade = grade + 2; }
                           
                        }
                        else if (j.Equals(1) && population[i].col[k][j] == 1)
                        {
                            if (k.Equals(0) && (population[i].col[k][j + 1] == 0 && population[i].col[k + 1][j] == 0 && population[i].col[k][j + 1] == 0)) { grade++; }
                          
                            else if (k.Equals(10) && (population[i].col[k][j + 1] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k][j + 1] == 0)) { grade++; }
                          
                            else if (population[i].col[k][j + 1] == 0 && population[i].col[k][j - 1] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k + 1][j] == 0) { grade++; }
                           
                        }

                        if (k.Equals(2) || k.Equals(3) || k.Equals(4) && population[i].col[k][j] == 1)
                        {
                            if (j.Equals(0) && (population[i].col[k + 1][j] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k][j + 1] == 0))
                            {
                                if (k.Equals(2) || k.Equals(4)) { grade++; } else if (k.Equals(3)) { grade = grade + 2; }
                            }
                            else if (j.Equals(10) && (population[i].col[k + 1][j] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k][j - 1] == 0))
                            {
                                if (k.Equals(2) || k.Equals(4)) { grade++; } else if (k.Equals(3)) { grade = grade + 2; }
                            }
                            else if (population[i].col[k][j + 1] == 0 && population[i].col[k][j - 1] == 0 && population[i].col[k - 1][j] == 0 && population[i].col[k + 1][j] == 0)
                            {
                                if (k.Equals(2) || k.Equals(4)) { grade++; } else if (k.Equals(3)) { grade = grade + 2; }
                            }
                        }
                    //
                    }
                }
            }
            return population;
        }//method T

    }//class Functions
}
