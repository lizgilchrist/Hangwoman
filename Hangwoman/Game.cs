using System;
using System.Collections.Generic;
using System.Text;

namespace Hangwoman
{
    public class Game
    {
        private Player _player1;
        private Player _player2;

        public Game(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void Start()
        {
            // Decides who the first leader is.
            Player leader = _player1;
            Player challenger = _player2;

            while (true)
            {
                Round round = new Round(leader, challenger);

                bool leaderWon = round.Start();
                if (leaderWon)
                {
                    Console.WriteLine();
                    Console.WriteLine("Unfortunately, " + challenger.Name + " you havn't guessed the secret word in time! You've lost this one :( ");

                    leader.Score++;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Congratulations, " + challenger.Name + " you guessed the secret word in time! You are now the new leader");

                    var oldLeader = leader;
                    leader = challenger;
                    challenger = oldLeader;

                    leader.Score++;
                    // Swap leader and challenger variables
                }

                Console.WriteLine();
                Console.WriteLine("The score is: " + _player1.Name + ": " + _player1.Score + " and " + _player2.Name + ": " + _player2.Score);
                Console.WriteLine();
                // Repeat round?
                Console.WriteLine("Would you like to continue playing? (Yes/No)");
                string playAgain = Console.ReadLine().ToLower();

                while (playAgain != "yes" && playAgain != "no")
                {
                    Console.WriteLine("Sorry, that's not a valid answer. Please try again.");
                    playAgain = Console.ReadLine().ToLower();
                }

                if (playAgain == "yes")
                {
                    Console.WriteLine("It's your turn to be leader, " + leader.Name + ". " + challenger.Name + " you are the challenger. ");
                }
                else
                {
                    Console.WriteLine("Goodbye! Until next time...");
                    break;
                }

            }
        }
    }
}
