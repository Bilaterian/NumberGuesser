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

            printIntro();

            //Get Name
            Console.WriteLine("What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine("Hello {0}, let's play a game...", userName);

            playGame();
        }

        //for printing game info to console
        static void printIntro()
        {
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
        }

        //the game itself
        static void playGame()
        {
            //for generating a new random number
            Random rnd = new Random();
            int randomNumber = 0;
            int userGuess = 0;
            bool repeat = true;
            
            while(repeat == true)
            {
                //setting random number between 1 and 20
                randomNumber = (rnd.Next() % 20) + 1;
                userGuess = 0;

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

                repeat = askRematch();
            }
            
        }

        //responsible for looping game
        static Boolean askRematch()
        {
            string response = "blah";
            Console.WriteLine("Play Again? (Y/N):");
            while (response != "Y" && response != "N")
            {
                response = Console.ReadLine().ToUpper();
                if (response == "Y")
                {
                    return true;
                }
                else if (response == "N")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please answer with Y or N.");
                }
            }
            return false;
        }
    }
}
