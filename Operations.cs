using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snowman
{
    public class Operations // Handles running the game.
    {
        public Words words = new();
        public List<char> guessed = new(); // Tracks letters that have been guessed.
        public int triesUsed;
        public string currentWord; // Stores the randomly chosen word.
        private char guess;
        public char[] blanks; // Used to display chars that haven't been guessed yet.
        public StringBuilder blanksAsString = new(); // Allows showing and updating unguessed letters/blanks.
        public StringBuilder guessedAsString = new(); // Allows display of guessed letters.

        public Operations()
        {
            currentWord = words.NewWord();
            blanks = new char[currentWord.Length];
            triesUsed = 0;
        }

        public void Start() // Displays welcome message and rules of the game. Waits for input before moving on.
        {
            UI.ShowText("Welcome! Time to play Snowman!\n\nYou will guess a single letter " + 
                        "at a time.\nIf it is correct, it will appear on screen.\n" +
                        "If not, it will appear in your guessed letters and the snowman " +
                        "will melt a little bit.\nIf you guess incorrectly 6 times, the " + 
                        "snowman will be gone!\n\nPress enter when you're finished reading" + 
                        " these instructions.");
            Console.ReadLine();

            Game();
        }

        public void Game() // This plays the game. There is no loop because any conditions that would end the game
        {
            Checks.CheckBlanks();
            UI.UpdateScreen(blanksAsString.ToString(), triesUsed, guessedAsString.ToString());
            guess = UI.GetLetter("Guess a letter: ");
            Checks.CheckGuess(guess);
            Checks.CheckWin();
        }

        public void PlayAgain() // Asks user if they want to keep playing and reruns Game or ends based on reply.
        {
            char keepPlaying = UI.GetLetter("Do you want to play again? (Y or N)");
            
            if(keepPlaying == 'Y' || keepPlaying == 'y')
            {
                ResetGame();
                Game();
            }
            else if (keepPlaying == 'N' || keepPlaying == 'n')
            {
                UI.ShowText("Thanks for playing! Hope to see you again soon!");
                Program.playAgain = false;
            }
            else
            {
                UI.ShowText("That's not a valid choice.\n");
                PlayAgain();
            }
        }

        private void ResetGame() // Gets new random word, empties blanks, guessed, the StringBuilders, and resets triesUsed so a new round can begin.
        {
            currentWord = words.NewWord();
            blanks = new char[currentWord.Length];
            guessed.Clear();
            blanksAsString.Clear();
            guessedAsString.Clear();
            triesUsed = 0;
        }
    }
}
