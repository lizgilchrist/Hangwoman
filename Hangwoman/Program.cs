using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangwoman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please flip a coin to decide who starts...");
            Console.WriteLine();
            Console.WriteLine("Who won? Please enter your name: ");
            string leader = Console.ReadLine();
            Console.WriteLine("Ok, the current leader is " + leader + ", but who is the challenger? Please enter your name: ");
            string challenger = Console.ReadLine();
            Console.WriteLine("Great! It's " + leader + " vs " + challenger + "! LETS START!");
            Console.WriteLine();
            //NOTE: Whoever wins will start and it's their turn to chose each word until they lose.
            Console.WriteLine(leader + ", please enter your secret word into the computer");
            string secretWord = Console.ReadLine();
            Console.Clear();

            foreach (char letter in secretWord)
            {
                string secretWordDisplay = "_" + " ";
                Console.Write(secretWordDisplay);
            }

            char correctLetter;

            List<char> guesses = new List<char>();
            //the loop will end when either the secretWord has been guessed or the woman is hung
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine(challenger + " please guess any letter of the alphabet");
                char guessedLetter = GetGuessedLetter();

                guesses.Add(guessedLetter);

                if (IsInWord(secretWord, guessedLetter))
                {
                    Console.WriteLine("You guessed it! " + guessedLetter + " is a letter from the secret word!");
                    correctLetter = guessedLetter;
                }
                else
                {
                    Console.WriteLine("Sorry but " + guessedLetter + " is not a letter from the secret word! Please try again");
                }


                SecretWordDisplay(secretWord, guesses);

            }

        }

        public static void SecretWordDisplay(string secretWord, List<char> guesses)
        {
            foreach (char letter in secretWord)
            {
                if(guesses.Contains(letter))
                {
                    Console.Write(letter + " ");
                }
                else
                {
                    string secretWordDisplay = "_" + " ";
                    Console.Write(secretWordDisplay);
                }
                
            }
        }

        private static bool IsInWord(string secretWord, char guessedLetter)
        {
            return secretWord.Any(letter => letter == guessedLetter);
            //return secretWord.Contains(guessedLetter.ToString());
            /*foreach (char letter in secretWord)
            {
                if (letter == guessedLetter)
               {
                    return true;
               }
            }
            return false;
            */
        }


        private static char GetGuessedLetter()
        {
            string guess = Console.ReadLine();
            char guessedLetter = guess[0];
            //TODO: Validations in here
            while (!char.IsLetter(guessedLetter))
            {
                Console.WriteLine("Sorry, that's not a valid answer. Please key in a letter of the alphabet (a-z)");
                guess = Console.ReadLine();
                guessedLetter = guess[0];
            }

            return guessedLetter;
        }
    }
}

