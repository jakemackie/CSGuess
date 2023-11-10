class Program
{
    // Method where the guessing game logic resides.
    static void Game(int targetInt, int maxInt) // Parameter: the number the user must guess.
    {
        bool gameActive = true; // Variable to track the game status (active/inactive).

        // Main game loop: continues until the user guesses the correct number.
        while (gameActive)
        {
            int guess; // Declare a variable to store the user's guess.
            Console.WriteLine($"What number (between 1-{maxInt}) am I thinking of?");
            string? userInput = Console.ReadLine(); // Read input from terminal as possible string.

            if (!int.TryParse(userInput, out guess)) // If we can't parse the string, handle the error.
            {
                Console.WriteLine("Invalid input, please enter a valid integer.");
                return; // Exit if the input is not a valid integer.
            }

            // Guess evaluation logic
            // If the guess is higher than the target number:
            if (guess > targetInt)
            {
                Console.WriteLine("Lower."); // Provide a hint to guess lower next time.
            }
            // If the guess is lower than the target number:
            else if (guess < targetInt)
            {
                Console.WriteLine("Higher."); // Provide a hint to guess higher next time.
            }
            // If the guess is correct:
            else
            {
                Console.ForegroundColor = ConsoleColor.Green; // Setting a green console color.
                Console.WriteLine($"You guessed it! I was thinking of {targetInt}"); // Success message.
                Console.ResetColor(); // Resetting the color of the terminal back to default.

                gameActive = false; // Set the game status to false, ending the game loop.
            }
        }
        // Close the game after 3 seconds
        Thread.Sleep(3000);
    }

    // Main entry point of the application.
    static void Main(string[] args)
    {
        int maxInt; // Declare expected integer
        Console.WriteLine("Set a maximum number:");
        string ?userInput = Console.ReadLine(); // Read input from terminal as possible string.

        if (!int.TryParse(userInput, out maxInt)) // If we can't parse the string, handle the error.
        {
            Console.WriteLine("Invalid input, please enter a valid integer.");
            return; // Exit if the input is not a valid integer.
        }
        // Generate and store a random integer between 1 and 100.
        Random randomInt = new Random();
        int targetInt = randomInt.Next(1, maxInt); // 101 exclusive to include 100.

        // Call the Game method, passing the targetInt & maxInt as parameters.
        Game(targetInt, maxInt);
    }
} 
