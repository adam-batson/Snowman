# Snowman
- User plays a hangman spinoff called snowman.
- The game starts with a welcome screen and some instructions and waits for the user to read them.
- A word from the hardcoded list is chosen at random each game.
- A mystery string of * is generated, matching the length of the word.
- The mystery string is shown to the player, allowing them to see the word length.
- The *s will be replaced with any correctly guessed letters.
- The screen updates each guess with a current mystery word, which letters have been guessed, and how many tries remain.
- The screen also shows a visual of a snowman that changes as it melts!
- Whether the user wins or loses, text is shown (lost games also show the snowman melted).
- After win/lose, the game asks if the user wants to play again.
- Game repeats until the user enters N.

## Project Objectives
- Demonstrate the S in SOLID: Single Responsibility

## Minimum Viable Product User Stores
- As a player, I want a simple welcome screen with brief instructions
- As a player, I want a word chosen randomly
- As a player, I want to see some sort of indication of the amount of letters in the word (or phrase). (Hint: - and _ are both good options)
- As a player, when I guess correctly, I want to see the letter added to the phrase
- As a player, when I guess incorrectly, I want to be told how many guesses I have left
- As a player, let me know when I win or lose the game
- After meeting the mvp user stories, feel free to continue adding your own features!

## Not Required
- A list of dashes is sufficient; there is not an expectation of a visual.
- The list of words may exist in an array or collection, it does not need to be read from a seperate file
- The game should be single player
