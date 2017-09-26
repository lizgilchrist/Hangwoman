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

            //NOTE: Whoever won last round this is where they will start - print current score
            while(true)
            {
                Console.WriteLine(leader + ", please enter your secret word into the computer");
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
                        numberOfIncorrectGuesses++;
                    }

                    SecretWordDisplay(secretWord, guesses);

                }

                if (numberOfIncorrectGuesses == 10)
                {
                    Console.WriteLine();
                    Console.WriteLine("Unfortunately, " + challenger + " you havn't guessed the secret word in time! You've lost this one :( ");
                    Console.WriteLine("Would you like to continue playing? (Yes/No)");
                    string playAgain = Console.ReadLine().ToLower();

                    while (playAgain != "yes" && playAgain != "no")
                    {
                        Console.WriteLine("Sorry, that's not a valid answer. Please try again.");
                        playAgain = Console.ReadLine().ToLower();
                    }

                    if (playAgain == "yes")
                    {
                        Console.WriteLine("That's the spirit, " + challenger + "!");
                        //Start new round and display score at the start of it
                    }
                    else
                    {
                        Console.WriteLine("The game's over!");
                        //Display final score - number of wins = number of times as leader. 
                        Console.WriteLine("Goodbye! Until next time...");
                        break;
                    }
                }

                if (IsSecretWordGuessed(secretWord, guesses))
                {
                    Console.WriteLine();
                    Console.WriteLine("Congratulations, " + challenger + " you guessed the secret word '" + secretWord + "' in time! You are now the new leader");

                    var oldLeader = leader;
                    leader = challenger;
                    challenger = oldLeader;

                    Console.WriteLine("Would you like to continue playing? (Yes/No)");
                    string playAgain = Console.ReadLine().ToLower();

                    while (playAgain != "yes" && playAgain != "no")
                    {
                        Console.WriteLine("Sorry, that's not a valid answer. Please try again.");
                        playAgain = Console.ReadLine().ToLower();
                    }

                    if (playAgain == "yes")
                    {
                        Console.WriteLine("It's your turn now to be leader, " + leader + ". " + oldLeader + " you are now the challenger. ");
                        //Start new round and display score at the start of it
                    }
                    else
                    {
                        Console.WriteLine("The game's over!");
                        //Display final score - number of wins = number of times as leader. 
                        Console.WriteLine("Goodbye! Until next time...");
                        break;
                    }
                }

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

