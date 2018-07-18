using System;

namespace Lab_3
{
    class Program
    {
        static void Main()
        {
            string userName;

            //ask the user for their name
            Console.WriteLine("What is your name?");
            userName = Console.ReadLine();

            Calc(userName);
        }

        static void Calc(string userName)
        {
            float userInput;
            string situ  = null;

            //get user input 1 - 100
            Console.WriteLine($"{userName}, please enter a number between 1 an 100.");
            if (!float.TryParse(Console.ReadLine(), out userInput))
            {
                //tell them to enter a number and call continue
                Console.WriteLine($"You need to enter a number, {userName}.");
                Continue(userName);
            }
            else if (userInput > 100 || userInput < 0)
            {
                //repeat to them the range and call continue
                Console.WriteLine($"{userName}, your number needs to be between 1 and 100.");
                Continue(userName);
            }
            //use mod2 (=1 odd, =0 even)
            else if (userInput % 2 == 1)
            {
                //if odd set 'situ' number and odd
                //if odd & > 60 set 'situ' number and odd
                situ = userInput.ToString() + " Odd";
            }
            else
            {
                if (userInput < 25)
                {
                    //if even & < 25 set 'situ' even and less than 25
                    situ = "Even and less than 25";
                }
                else if (userInput > 25)
                {
                    //if even & between 26 and 60 set 'situ' even
                    situ = "Even";
                }             
            }

            if (situ != null)
            Console.WriteLine(situ);

            Continue(userName);
        }

        static void Continue(string userName)
        {
            string response;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Continue? (y/n): ");
                response = Console.ReadLine().ToLower();

                if (response == "y" || response == "yes")
                {
                    //if yes, restart at calc
                    Calc(userName);
                }
                else if (response == "n" || response == "no")
                {
                    //if no, exit
                    i = 5;
                    return;
                }

                if (i <= 2 && response != "n" && response != "no" && response != "y" && response != "yes")
                {
                    //if the user enters neither, inform and repeat
                    Console.WriteLine($"Sorry {userName}, I could not understand your response.");
                    Console.WriteLine("Please enter a valid response.");
                }
                else if (i == 3 && response != "n" && response != "no" && response != "y" && response != "yes")
                {
                    Console.WriteLine($"Sorry {userName}, I could not understand your response.");
                    Console.WriteLine("If a vaild response is not entered on this attempt the program will end");
                }
                else if (i == 4 && response != "n" && response != "no" && response != "y" && response != "yes")
                {
                    Console.WriteLine($"Sorry {userName}, I could not understand your response.");
                    Console.WriteLine("You have run out of continue attempts and the program has terminated.");
                    i = 5;
                }
            }
            return;
        }
    }
}