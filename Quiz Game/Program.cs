using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Quiz_Game
{
    class Program
    {


        static void Main(string[] args)
        {

            string[] questions = new string[10];
            string[] answers = new string[3];
            string[,] options = new string[10, 3];
            int[] key = new int[10];
            int score = 0;
            string player;
            char letter = 'A';
            char guess;

            Stopwatch stopwatch = new Stopwatch();

            

            Random rnd;

            Console.WindowWidth = 90;
            Console.WindowHeight = 25;


            DateTime Now = DateTime.Now;


            /* ***************** QUESTIONS ***************** */
            questions[0] = "Which of the following is correct about variable naming conventions in C#?";
            questions[1] = "Which of the following is correct about dynamic Type in C#?";
            questions[2] = "Which of the following converts a type to a double type in C#?";
            questions[3] = "Which of the following operator represents a conditional operation in C#?";
            questions[4] = "Which of the following method helps in returning more than one value?";
            questions[5] = "Which of the following property of Array class in C# gets a 64-bit integer, the total number of elements in all the dimensions of the Array?";
            questions[6] = "Which of the following is the correct about class member variables?";
            questions[7] = "Which of the following is the correct about static member functions of a class?";
            questions[8] = "Which of the following preprocessor directive specifies the end of a conditional directive in C#?";
            questions[9] = "User-defined exception classes are derived from the ApplicationException class in C#?";

            //**********************************************************************
            /* ALL Options   */
            //*********************Question 1 options*************************************************
            options[0, 0] = "Both";//right
            options[0, 1] = "It should not be a C# keyword";
            options[0, 2] = "It must not contain any embedded space or symbol such as? - + ! @ # % ^ & * ( ) [ ] { }";
            //*********************Question 2 options*************************************************
            options[1, 0] = "You can store any type of value in the dynamic data type variable";
            options[1, 1] = "Both";//right
            options[1, 2] = "Type checking for these types of variables takes place at run-time";
            //*********************Question 3 options*************************************************
            options[2, 0] = "ToInt32";
            options[2, 1] = "ToDouble";//right
            options[2, 2] = "ToDecimal";
            //*********************Question 4 options*************************************************
            options[3, 0] = "is";
            options[3, 1] = "as";
            options[3, 2] = "?:";//right
            //*********************Question 5 options*************************************************
            options[4, 0] = "Output parameters";//right
            options[4, 1] = "Reference parameters";
            options[4, 2] = "Value parameters";
            //*********************Question 6 options*************************************************
            options[5, 0] = "LongLength";//right
            options[5, 1] = "Rank";
            options[5, 2] = "Length";
            //*********************Question 7 options*************************************************
            options[6, 0] = "These private variables can only be accessed using the public member functions";
            options[6, 1] = "Both";//right
            options[6, 2] = "Member variables are the attributes of an object (from design perspective) and they are kept private to implement encapsulation";
            //*********************Question 8 options*************************************************
            options[7, 0] = "All";//right
            options[7, 1] = "You can also declare a member function as static";
            options[7, 2] = "Such functions can access only static variables";
            //*********************Question 9 options*************************************************
            options[8, 0] = "elif";
            options[8, 1] = "if";
            options[8, 2] = "endif";//right
            //*********************Question 10 options*************************************************
            options[9, 0] = "true";//right
            options[9, 1] = "false";
            options[9, 2] = "error";
            //Key Numbers 
            key[0] = 0;
            key[1] = 1;
            key[2] = 1;
            key[3] = 2;
            key[4] = 0;
            key[5] = 0;
            key[6] = 1;
            key[7] = 0;
            key[8] = 2;
            key[9] = 0;

            int x = 0;
            int y = 0;


            Console.WriteLine("Date: " + Now);
            Console.Write("Player Name: ");
            player = Console.ReadLine();
            Console.Clear();
            stopwatch.Start();
            while (true)
            {
                Console.Write("Player Name: ");
                Console.WriteLine(player);

             
                Console.WriteLine("Score : " + score);

                y = key[x];
                //assigning options
                for (int i = 0; i < 3; i++)
                {
                    answers[i] = options[x, i];
                }

                //shuffiling  options
                rnd = new Random();
                answers = answers.OrderBy(n => rnd.Next()).ToArray();

                Console.WriteLine("************QUESTION - " + (x + 1) + "************\n\n");
                Console.WriteLine(questions[x] + "\n");



                foreach (var item in answers)
                {
                    Console.WriteLine($"{letter}){item}");
                    letter++;
                    Console.WriteLine();
                }
                letter = 'A';

                Console.Write("Answer is : ");
                guess = Console.ReadKey().KeyChar;


                switch (guess)
                {
                    case 'a':
                    case 'A':
                        {
                            if (answers[0] == options[x, y]) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Correct!"); score += 10; }
                            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Incorrect!"); if (score != 0) score -= 10; }
                            break;
                        }

                    case 'b':
                    case 'B':
                        {
                            if (answers[1] == options[x, y]) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Correct!"); score += 10; }
                            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Incorrect!"); if (score != 0) score -= 10; }
                            break;
                        }
                    case 'c':
                    case 'C':
                        {
                            if (answers[2] == options[x, y]) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Correct!"); score += 10; }
                            else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Incorrect!"); if (score != 0) score -= 10; }
                            break;

                        }
                }

                x++;
                Thread.Sleep(1000);
                Console.Clear();
                Console.ResetColor();
                if (x == 10) break;
            }
            stopwatch.Stop();
            Console.WriteLine("Start Date : " + Now);
            Now = DateTime.Now;
            Console.WriteLine("End   Date : " + Now);
            Console.WriteLine("Time elapsed:  " + stopwatch.Elapsed);
            Console.WriteLine("Player Name: " + player);
            if (score == 100)
            {
                Console.WriteLine("Congratulations!!!");
                Console.WriteLine("You answered all questions Correctly");
                Console.WriteLine("Your score is " + score);
            }
            else
            {
                Console.Write("Score: ");
                Console.WriteLine(score);
            }

            


        }


    }
}

