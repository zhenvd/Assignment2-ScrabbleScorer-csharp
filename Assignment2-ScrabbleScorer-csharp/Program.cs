using System;
using System.Collections.Generic;
using System.Linq;

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
        public static Dictionary<char, int> newPointStructure = new Dictionary<char, int>();



        //Code your Transform method here
        static void Transform()
        {

            foreach (KeyValuePair<int, string> pairs in oldPointStructure)
            {
                    char[] charArray = pairs.Value.ToCharArray(); //sends all letters including commas and spaces to array
                    for(int i = 0; i < charArray.Length; i++)
                    {
                        if(!(charArray[i].Equals(" ") || charArray[i].Equals(",")))
                        {
                            if(!(newPointStructure.Keys.Contains(charArray[i])))
                            {
                                newPointStructure.Add(charArray[i], pairs.Key);
                            }
                           
                        }
                        
                    }
            }

        }
        
        //Code your Scoring Option methods here

        //SimpleScorer-----
        public static void SimpleScore(string word)
        {
            int count = 0;
            foreach(char letter in word)
            {
                count++;
            }
            Console.WriteLine($"Your word '{word}' is worth {count} points.");
        }
        //BonusVowels-----
        public static void BonusVowels(string word)
        {
            int count = 0;
            int vowelCount = 0;
            string vowels = "AEIOU";
            foreach (char letter in word) //cycles through each character
            {
                foreach(char vowelLetter in vowels) //if cycles through all vowels
                {
                    if(letter.Equals(vowelLetter)) //compares to see if there is a vowel. 
                    {
                        vowelCount++; //is vowel
                    }
                }
                count++;
            }
            count = (vowelCount * 3) + (count - vowelCount);
            Console.WriteLine($"Your word '{word}' is worth {count} points.");
        }
        //ScrabbleScorer-----
        public static void ScrabbleScore(string word)
        {
            int count = 0;
            foreach (char letter in word) //cycles each character in word
            {
                foreach(KeyValuePair<char, int> letterPairs in newPointStructure) //cycles through entire point system
                {
                    if(letterPairs.Key.Equals(letter)) //if there is a match, give appropriate amt of points
                    {
                        count += letterPairs.Value; //based on Key/Value
                    }
                }
            }
            Console.WriteLine($"Your word '{word}' is worth {count} points.");
        }

        //Code your ScoringAlgorithms method here

        static void ScoringAlgorithms(int output, string word = "taxi")
        {
            if(output == 1)
            {
                ScrabbleScore(word);
            }
            else if (output == 2)
            {
                SimpleScore(word);
            }
            else
            {
                BonusVowels(word);
            }
        }



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
                            //does nothing
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

        static void RunProgram()
        {
            string end = "0";
            bool exit = true;
            int choice = InitialPrompt();
            while(exit)
            {
                Console.WriteLine("Please enter a word to score. Type '0' to end.");
                string wordInput = Console.ReadLine().ToUpper();
                if(wordInput.Equals(end))
                {
                    break;
                }
                ScoringAlgorithms(choice, wordInput);
            }
            Console.WriteLine("Thanks for playing!");
        }




        static void Main(string[] args)
        {
            //Call your RunProgram method here
            Transform();
            RunProgram();
            Console.ReadLine();




        }
    }
}
