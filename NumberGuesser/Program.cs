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
            string intro = appName + ": Version " + appVersion + " by " + appAuthor;
            printColorMessage(intro, ConsoleColor.Green);
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

                printColorMessage("Guess a number between 1 and 20.", ConsoleColor.Yellow);

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
                            printColorMessage("Higher...", ConsoleColor.Magenta);
                        }
                        //number too high
                        else if (userGuess > randomNumber)
                        {
                            printColorMessage("Lower...", ConsoleColor.Cyan);
                        }
                    }

                }
                //congratulates the user for guessing correctly
                printColorMessage("You got it!", ConsoleColor.Green);

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

        static void printColorMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
