
using System.Net;

namespace BärShell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Get current user and hostname
            var shelluser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //assign a variable to keep the shell running
            int keeprunning = 1;

            Console.WriteLine("Bärshell v0.1 - a rudimentary shell which helps me learn programming.");
            Console.WriteLine("Copyright: B. Fellner / CPElite | 2023");
            Console.WriteLine("Enter a command, type help for a list of available commands.");

            while (keeprunning == 1)
            {
                //Coloring the prompt
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(shelluser + "> ");
                Console.ResetColor();

                //Waiting for Commands
                var input = Console.ReadLine();
                var co = input;
                var vars = "";
                if (input.ToLower().IndexOf('/') != -1)
                {
                    string[] parts = input.Split('/');
                    co = parts[0];
                    vars = parts[1];
                }

                //Switches for commands
                switch (co)
                {
                    case "help":
                        misc.help();
                        break;

                    case "exit":
                        keeprunning++;
                        break;
                }
            }

        }

    }
}