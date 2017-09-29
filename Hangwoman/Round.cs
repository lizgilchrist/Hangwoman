using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangwoman
{
    public class Round
    {
        private Player _leader;
        private Player _challenger;

        public Round(Player leader, Player challenger)
        {
            _leader = leader;
            _challenger = challenger;
        }

        /// <summary>
        /// Starts the round
        /// 
        /// </summary>
        /// <returns>Returns true if the leader wins, false if the challenger wins.</returns>
        /// 

        public bool Start()
        {

            Console.WriteLine();
            Console.WriteLine(_leader.Name + ", please enter your secret word into the computer");
            string secretWord = Console.ReadLine();
            Console.Clear();

            foreach (char letter in secretWord)
            {
                string secretWordDisplay = "_" + " ";
                Console.Write(secretWordDisplay);
            }

            char correctLetter;

            int numberOfIncorrectGuesses = 0;

            List<char> guesses = new List<char>();

            while (!IsSecretWordGuessed(secretWord, guesses) && numberOfIncorrectGuesses <= 10)
            {
                Console.WriteLine();
                Console.WriteLine(_challenger.Name + " please guess any letter of the alphabet");
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
                    numberOfIncorrectGuesses++;
                }

                SecretWordDisplay(secretWord, guesses);

            }

            return !IsSecretWordGuessed(secretWord, guesses);
            
        }

        public static void SecretWordDisplay(string secretWord, List<char> guesses)
        {
            foreach (char letter in secretWord)
            {
                if (guesses.Contains(letter))
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
            string guess = Console.ReadLine().ToLower();
            char guessedLetter = guess[0];

            while (!char.IsLetter(guessedLetter))
            {
                Console.WriteLine("Sorry, that's not a valid answer. Please key in a letter of the alphabet (a-z)");
                guess = Console.ReadLine().ToLower();
                guessedLetter = guess[0];
            }

            return guessedLetter;
        }
        private static bool IsSecretWordGuessed(string secretWord, List<char> guesses)
        {
            foreach (char letter in secretWord)
            {
                if (!guesses.Contains(letter))
                {
                    return false;
                }

            }
            return true;
        }
    }
    
}
