using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_ScissorsGameAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput, systemInput;

            int randomNum;
            string ans;

            do
            {
                Console.WriteLine("Give an input from Rock/ Paper/ Scissor/ Spock/ Lizard:  ");

                userInput = Console.ReadLine();



                Random rnd = new Random();

                randomNum = rnd.Next(1, 6);




                switch (randomNum)

                {

                    case 1:

                        systemInput = "Rock";

                        Console.WriteLine("Computer chose Rock");

                        if (userInput == "Rock")

                        {

                            Console.WriteLine("It is a draw");

                        }
                        else if (userInput == "Paper" || userInput == "Spock")

                        {

                            Console.WriteLine("You Win");

                        }

                        else if (userInput == "Scissor" || userInput == "Lizard")

                        {

                            Console.WriteLine("You Loose");

                        }

                        break;

                    case 2:

                        systemInput = "Paper";

                        Console.WriteLine("Computer chose Paper");

                        if (userInput == "Rock" || userInput == "Spock")

                        {

                            Console.WriteLine("You Loose");

                        }

                        else if (userInput == "Paper")

                        {

                            Console.WriteLine("It is a draw");

                        }

                        else if (userInput == "Scissor" || userInput == "Lizard")

                        {

                            Console.WriteLine("You win");

                        }

                        break;

                    case 3:

                        systemInput = "Scissor";

                        Console.WriteLine("Computer chose Scissor");

                        if (userInput == "Rock" || userInput == "Spock")

                        {

                            Console.WriteLine("You Win");

                        }

                        else if (userInput == "Paper" || userInput == "Lizard")

                        {

                            Console.WriteLine("You Loose");

                        }

                        else

                        {

                            Console.WriteLine("It is a draw");

                        }

                        break;
                    case 4:
                        systemInput = "Spock";

                        Console.WriteLine("Computer chose Spock");

                        if (userInput == "Spock")

                        {

                            Console.WriteLine("It is a draw");

                        }
                        else if (userInput == "Paper" || userInput == "Lizard")

                        {

                            Console.WriteLine("You Win");

                        }

                        else if (userInput == "Scissor" || userInput == "Rock")

                        {

                            Console.WriteLine("You Loose");

                        }

                        break;

                    case 5:
                        systemInput = "Lizard";

                        Console.WriteLine("Computer chose Lizard");

                        if (userInput == "Lizard")

                        {

                            Console.WriteLine("It is a draw");

                        }
                        else if (userInput == "Paper" || userInput == "Spock")

                        {

                            Console.WriteLine("You Loose");

                        }

                        else if (userInput == "Rock" || userInput == "Scissor")

                        {

                            Console.WriteLine("You Win");

                        }

                        break;


                    default:

                        Console.WriteLine("invalid entry!");

                        break;

                }

                Console.WriteLine("Do You Want Continue : 'Y' or 'y' or 'N' or 'n'");
                ans = Console.ReadLine();
            } while (ans == "y" || ans == "Y");

        }
    }
}
