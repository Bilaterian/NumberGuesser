using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NameSpace
namespace NumberGuesser
{
    // Main Class
    internal class Program
    {
        //Entry Point method
        static void Main(string[] args)
        {
            //START HERE//
            //Console.WriteLine("Hello World");
            //Console.WriteLine("{0} {1}", "Hello", "World");

            //Set App Vars
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Lance Paje";

            //Set Console Name
            Console.Title = appName;

            //Change Text Color
            Console.ForegroundColor = ConsoleColor.Green;

            //Writes Title
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);

            //Removes Color
            Console.ResetColor();

            //Get Name
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello {0}, let's play a game...", userName);

            playGame();
        }

        //the game itself
        static void playGame()
        {
            //for generating a new random number
            Random rnd = new Random();

            //setting random number between 1 and 20
            int randomNumber = (rnd.Next() % 20) + 1;
            int userGuess = 0;
            bool repeat = true;
            
            while(repeat == true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Guess a number between 1 and 20.");
                Console.ResetColor();

                //keeps looping until user makes the correct guess
                while (randomNumber != userGuess)
                {
                    string input = Console.ReadLine();
                    bool hasException = false;

                    //try catch block to catch wrong input formats
                    try
                    {
                        userGuess = Int32.Parse(input);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("I don't think that's a number...");
                        hasException = true;
                    }

                    //prints messages if user uses correct input format
                    if (hasException == false)
                    {
                        //number too low
                        if (userGuess < randomNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Higher...");
                            Console.ResetColor();
                        }
                        //number too high
                        else if (userGuess > randomNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Lower...");
                            Console.ResetColor();
                        }
                    }

                }
                //congratulates the user for guessing correctly
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You got it!");
                Console.ResetColor();

                string response = "blah";
                Console.WriteLine("Play Again? (Y/N):");
                while (response != "Y" && response != "N")
                {
                    response = Console.ReadLine();
                    if(response == "Y")
                    {
                        repeat = true;
                        randomNumber = (rnd.Next() % 20) + 1;
                        userGuess = 0;
                    }
                    else if(response == "N")
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Please answer with Y or N.");
                    }
                }
                
            }
            
        }
    }
}
