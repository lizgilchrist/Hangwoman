using System;

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

            foreach(char i in secretWord)
            {
                string displaySecretWord = "_" + " ";
                Console.Write(displaySecretWord);
            }
            Console.WriteLine();
            Console.WriteLine(challenger + " take a guess at the secret word by choosing any letter of the alphabet");
            
            //NOTE: Replace every letter with a _ dash on screen
        }
    }
}

