using System;
using System.Collections.Generic;

namespace Assignment2_ScrabbleScorer_csharp
{
    class Program
    {
        //Here is the original OldPointStructure dictionay
        public static Dictionary<int, string> oldPointStructure = new Dictionary<int, string>()
        {
            {1, "A, E, I, O, U, L, N, R, S, T"},
            {2, "D, G"},
            {3, "B, C, M, P" },
            {4, "F, H, V, W, Y" },
            {5, "K" },
            {8, "J, X" },
            {10, "Q, Z" }
        };




        //Code your Transform method here






        //Code your Scoring Option methods here

        //SimpleScorer-----
        public static void SimpleScorer()
        {

        }


        //BonusVowels-----




        //ScrabbleScorer-----





        //Code your ScoringAlgorithms method here





        //Code your InitialPrompt method here

        static int InitialPrompt()
        {
            Console.WriteLine("Welcome to the Scrabble score calculator!" +
                "\nWhich scoring algorithm would you like to use?" +
                "\n1 - Scrabble: The traditional scoring algorithm." +
                "\n2 - Simple Score: Each letter is worth 1 point." +
                "\n3 - Bonus Vowels: Vowels are worth 3 pts, and consonants are 1 pt." +
                "\n\nEnter 1, 2 or 3: ");
            string choiceString = Console.ReadLine();
            /*int intChoice = int.Parse(choiceString);*/
            int intChoice;
            int output = 0;
            bool exit = true;
            while(exit)
            {
                if (int.TryParse(choiceString, out intChoice))
                {
                    while (intChoice < 1 || intChoice > 3)
                    {
                        Console.WriteLine("Please enter 1, 2 or 3: ");
                        choiceString = Console.ReadLine();
                        if (int.TryParse(choiceString, out intChoice))
                        {
                            
                        }
                    }
                    exit = false; //exits while loop
                    output = intChoice;
                }
                else
                {
                    Console.WriteLine("Please enter a numeric value.");
                    choiceString = Console.ReadLine();
                }
            }

            return output;

        }




        //Code your RunProgram method here






        static void Main(string[] args)
        {
            //Call your RunProgram method here
            InitialPrompt();





        }
    }
}
