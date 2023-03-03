# Spanzuratoarea

This is a hangman game written in C# using Windows Forms. The objective of the game is to guess a hidden word by
suggesting letters one at a time. If the suggested letter is part of the word, all occurrences of that letter are revealed.
Otherwise, a part of a hangman figure is drawn. The game continues until the player correctly guesses the word or the hangman figure is completed.

## Installation
To install the game, download or clone the repository to your local machine and open the solution file **"Spanzuratoarea.sln"** in Visual Studio.
Then, build the solution and run the application. Alternatively, you can download the **"Spanzuratoarea.exe"** file from the **"bin/Debug"** folder
and run it directly on your Windows machine.

## Usage
To start a new game, click on the "New Game" button. A random word will be selected from a predefined list, and its
length will be displayed as a series of underscores. Click on the letter buttons to suggest letters. If the letter is part of the word,
it will replace the corresponding underscores. If the letter is not part of the word, a part of the hangman figure will be displayed,
and the letter button will be disabled. The game ends when the word is correctly guessed, or the hangman figure is fully displayed.

You can use the "Hint" button to reveal a random letter from the word. However, you can only use this feature twice per game.
