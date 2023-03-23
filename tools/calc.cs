using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BärShell.tools
{
    public class calc
    {

        public static void init()
        {
            //Initialize and Declare Variables
            double num1 = 0;
            double num2 = 0;

            //Title
            Console.WriteLine("BearShell Calculator");
            Console.WriteLine("--------------------\n");

            //Ask for first number
            Console.WriteLine("Enter the first number:");
            num1 = Convert.ToDouble(Console.ReadLine());

            //Ask for second number
            Console.WriteLine("Enter the second number:");
            num2 = Convert.ToDouble(Console.ReadLine());

            //Let the user choose a operation
            Console.WriteLine("Choose a option from the following list:");
            Console.WriteLine("a - Addition");
            Console.WriteLine("s - subtract");
            Console.WriteLine("m - multiply");
            Console.WriteLine("d - divide");
            Console.Write("Your option?");

            // Using a switch statement to do the math.
            switch (Console.ReadLine())
            {
                case "a":
                    Console.WriteLine($"Your result: {num1 + num2}");
                    break;

                case "s":
                    Console.WriteLine($"Your result: {num1 - num2}");
                    break;

                case "m":
                    Console.WriteLine($"Your result: {num1 * num2}");
                    break;

                case "d":
                    Console.WriteLine($"Your result: {num1 / num2}");
                    break;


            }

        }
    }
}
