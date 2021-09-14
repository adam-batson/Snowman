using System;

namespace Snowman
{
    class Program
    {
        public static bool playAgain = true;
        public static Operations ops = new();

        static void Main(string[] args)
        {

            ops.Start(); // Only shows welcome message once on game start, rather than every round.

            while (playAgain) // Repeats game until the user decides they are done.
            {
                ops.Game();
            }
        }
    }
}
