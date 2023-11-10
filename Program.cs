/*
    MIT License

    Project: Number Guessing Game
    Description: This C# console application implements a simple number guessing game.
    
    Author: vswc
    Version: 1.1 (stable)
    Date: November 10, 2023

*/

using System.Diagnostics;

class Program
{    
    static void Game(int targetInt, int maxInt) 
    {
        Stopwatch stopwatch = new Stopwatch();
        bool gameActive = true; 
        stopwatch.Start();

        
        while (gameActive)
        {
            int guess; 
            Console.WriteLine($"What number (between 1-{maxInt}) am I thinking of?");
            string? userInput = Console.ReadLine(); 

            if (!int.TryParse(userInput, out guess)) 
            {
                Console.WriteLine("Invalid input, please enter a valid integer.");
                Thread.Sleep(3000);
                return; 
            }

            
            
            if (guess > targetInt)
            {
                Console.WriteLine("Lower."); 
            }
            
            else if (guess < targetInt)
            {
                Console.WriteLine("Higher."); 
            }
            
            else
            {
                stopwatch.Stop();
                double elapsedSeconds = Math.Round(stopwatch.Elapsed.TotalSeconds, 2);

                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine($"Guessed in {elapsedSeconds}s! I was thinking of {targetInt}"); 
                Console.ResetColor(); 

                gameActive = false; 
            }
        }
        
        Thread.Sleep(3000);
    }

    static void Main(string[] args)
    {
        int maxInt; 
        Console.WriteLine("Set a maximum number:");
        string ?userInput = Console.ReadLine(); 

        if (!int.TryParse(userInput, out maxInt)) 
        {
            Console.WriteLine("Invalid input, please enter a valid integer.");
            Thread.Sleep(3000);
            return; 
        }
        
        Random randomInt = new Random();
        int targetInt = randomInt.Next(1, maxInt); 

        Game(targetInt, maxInt);
    }
} 
 