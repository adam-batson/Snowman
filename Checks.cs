using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowman
{
    public static class Checks // Handles checking the guesses, if blanks need updates, and if the game is won.
    {
        public static void CheckGuess(char guess)
        {
            if (!Char.IsLetter(guess)) // Verifies the guess is a letter and gets a new guess if it isn't.
            {
                if (guess == ' ')
                {
                    UI.ShowText("You entered nothing. Try again.\n");
                }
                else
                {
                    UI.ShowText($"{guess} isn't a letter. Try again.\n");
                }
            }
            else
            {
                guess = Char.ToUpper(guess); // Words are stored in caps, so this converts the guess to a capital letter.
            }

            if (Program.ops.guessed.Contains(guess)) // Validates guess wasn't already guessed.
            {
                UI.ShowText("You already guessed that letter. Try again.\n");
            }
            else if (Program.ops.currentWord.Contains(guess)) // Checks if guess is in the word.
            {
                UI.ShowText($"Yes! {guess} is in the word!\n");
                Program.ops.guessed.Add(guess);
                Program.ops.guessedAsString.Append(guess);
                Program.ops.guessedAsString.Append(' ');
                CheckBlanks(); // Updates revealed letters.
            }
            else
            {
                UI.ShowText($"Sorry, {guess} is not in the word.\n");
                Program.ops.triesUsed++;
                Program.ops.guessed.Add(guess);
                Program.ops.guessedAsString.Append(guess);
                Program.ops.guessedAsString.Append(' ');
            }
        }

        public static void CheckBlanks() // Adds guessed letters to the blanks, eventually becoming a copy of the goal word.
        {
            var length = Program.ops.currentWord.Length;
            Program.ops.blanksAsString.Clear();

            for (int i = 0; i < length; i++)
            {
                if (Program.ops.guessed.Contains(Program.ops.currentWord[i])) // If player guessed the letter of the goal word we're looking at now, change the blank to that letter.
                {
                    Program.ops.blanksAsString.Append(Program.ops.currentWord[i]);
                }
                else // Fill in blanks for unknown letters.
                {
                    Program.ops.blanksAsString.Append('*');
                }
            }
        }

        public static void CheckWin() // Checks if the game is won or lost and either keeps the game running or asks user if they want to play again.
        {
            if (Program.ops.triesUsed == 6) // Lose condition - player used up all tries.
            {
                UI.ShowSnowman(Program.ops.triesUsed);
                UI.ShowText($"The snowman melted away and you lost this round! The word was {Program.ops.currentWord}.\n");
                Program.ops.PlayAgain();
            }
            else if (Program.ops.blanksAsString.ToString() == Program.ops.currentWord) // Win condition - player matched the word.
            {
                UI.ShowText($"Congratulations! You guessed the word {Program.ops.currentWord} with {6 - Program.ops.triesUsed} tries left!\nYou saved the snowman and won this round!\n");
                Program.ops.PlayAgain();
            }
            else // Player didn't win or lose, game keeps going.
            {
                Program.ops.Game();
            }
        }
    }
}
