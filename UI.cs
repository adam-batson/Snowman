using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowman
{
    public class UI
    {   // Snowman is a UI component, so instantiates one for use in this class.
        static readonly Snowman sm = new();

        public static void ShowText(string text) => Console.WriteLine(text);

        public static char GetLetter(string text)
        {
            ShowText(text);
            var output = Console.ReadLine();
            if (output != "")
            {
                return output[0];
            }
            else
            {
                return ' ';
            }
        }

        public static void ShowGuessed(string guessed) => Console.WriteLine($"Guessed letters: {guessed}");

        public static void ShowSnowman(int tries) => ShowText("\n" + sm.SnowmanParts[tries] + "\n");

        private static void ShowTries(int tries) => ShowText($"Tries remaining: {6 - tries}\n");

        public static void UpdateScreen(string blanks, int tries, string guessed)
        {
            ShowSnowman(tries);
            ShowText(blanks);
            ShowGuessed(guessed);
            ShowTries(tries);
        }
    }
}
