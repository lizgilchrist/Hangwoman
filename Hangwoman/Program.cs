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

            Game game = new Game(
                new Player() { Name = leader },
                new Player() { Name = challenger}
                );

            game.Start();
        }

    }
}