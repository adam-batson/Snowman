using System;

namespace Snowman
{
    class Program
    {
        public static bool playAgain = true;
        static readonly Operations ops = new();
        static void Main(string[] args)
        {
            ops.Start();

            while (playAgain)
            {
                ops.Game();
            }
        }
    }
}
