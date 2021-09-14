using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Snowman
{
    public class Operations
    {
        public Words words = new();
        public List<char> guessed = new(); // Tracks letters that have been guessed.
        public int triesUsed;
        private string currentWord; // Stores the randomly chosen word.
        private char guess;
        public char[] blanks; // Used to display chars that haven't been guessed yet.
        private UI ui = new();
        private StringBuilder blanksAsString = new();
        private StringBuilder guessedAsString = new();

        public Operations()
        {
            currentWord = words.NewWord();
            blanks = new char[currentWord.Length];
            triesUsed = 0;

        }

        public void Start()
        {
            ui.ShowText("Welcome! Time to play Snowman!\n\nYou will guess a single letter " + 
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
            CheckBlanks();
            ui.UpdateScreen(blanksAsString.ToString(), triesUsed, guessedAsString.ToString());
            guess = ui.GetLetter("Guess a letter: ");
            CheckGuess(guess);
            CheckWin();
        }

        private void CheckGuess(char guess)
        {
            if (!Char.IsLetter(guess)) // Verifies the guess is a letter and gets a new guess if it isn't.
            {
                if(guess == '~')
                {
                    ui.ShowText("You entered nothing. Try again.\n");
                }
                else
                {
                    ui.ShowText($"{guess} isn't a letter. Try again.\n");
                }
            }           
            else
            {
                guess = Char.ToUpper(guess); // Words are stored in caps, so this converts the guess to a capital letter.
            }

            if (guessed.Contains(guess)) // Validates guess wasn't already guessed.
            {
                ui.ShowText("You already guessed that letter. Try again.\n");
            }
            else if (currentWord.Contains(guess)) // Checks if guess is in the word.
            {
                ui.ShowText($"Yes! {guess} is in the word!\n");
                guessed.Add(guess);
                guessedAsString.Append(guess);
                guessedAsString.Append(' ');
                CheckBlanks(); // Updates revealed letters.
            }
            else
            {
                ui.ShowText($"Sorry, {guess} is not in the word.\n");
                triesUsed++;
                guessed.Add(guess);
                guessedAsString.Append(guess);
                guessedAsString.Append(' ');
            }
        }

        private void CheckBlanks() // Adds guessed letters to the blanks, eventually becoming a copy of the goal word.
        {
            var length = currentWord.Length;
            blanksAsString.Clear();

            for (int i = 0; i < length; i++)
            {
                if (guessed.Contains(currentWord[i])) // If player guessed the letter of the goal word we're looking at now, change the blank to that letter.
                {
                    blanksAsString.Append(currentWord[i]);
                }
                else // Fill in blanks for unknown letters.
                {
                    blanksAsString.Append('*');
                }
            }
        }

        private void CheckWin() // Checks if the game is won or lost and either keeps the game running or asks user if they want to play again.
        {
            //ui.UpdateScreen(blanksAsString.ToString(), triesUsed, guessedAsString.ToString());

            if (triesUsed == 6) // Lose condition - player used up all tries.
            {
                ui.ShowSnowman(triesUsed);
                ui.ShowText("The snowman melted away and you lost this round!\n");
                PlayAgain();
            }
            else if(blanksAsString.ToString() == currentWord) // Win condition - player matched the word.
            {
                ui.ShowText($"Congratulations! You guessed the word {currentWord} with {6 - triesUsed} tries left!\nYou saved the snowman and won this round!\n");
                PlayAgain();
            }
            else // Player didn't win or lose, game keeps going.
            {
                Game();
            }
        }

        private void PlayAgain()
        {
            char keepPlaying = ui.GetLetter("Do you want to play again? (Y or N)");
            
            if(keepPlaying == 'Y' || keepPlaying == 'y')
            {
                ResetGame();
                Game();
            }
            else if (keepPlaying == 'N' || keepPlaying == 'n')
            {
                ui.ShowText("Thanks for playing! Hope to see you again soon!");
                Program.playAgain = false;
            }
            else
            {
                ui.ShowText("That's not a valid choice.\n");
                PlayAgain();
            }
        }

        private void ResetGame()
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
