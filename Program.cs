using System.Net;
using System.IO;
using static BearShell.fstools;
using System.Security.Cryptography.X509Certificates;

namespace BearShell
{
    public class Program
    {
        public static void Main()
        {
            //Get current user and hostname
            var shelluser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            //assign a variable to keep the shell running
            int keeprunning = 1;

            //Get current path (absolute path!)
            string path = Directory.GetCurrentDirectory();

            Console.WriteLine("Bärshell v0.2 - a rudimentary shell which helps me learn programming.");
            Console.WriteLine("Copyright: B. Fellner / CPElite | 2023");
            Console.WriteLine("Enter a command, type help for a list of available commands. Type fscommands for a list of file operation related commands.");

            while (keeprunning == 1)
            {
                //Coloring the prompt
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(shelluser);
                Console.ResetColor();
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(path + " ");
                Console.ResetColor();

                //Waiting for Commands
                var input = Console.ReadLine();
                var co = input;
                var vars = " ";
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

                    case "fscommands":
                        misc.fscommands();
                        break;

                    case "exit":
                        keeprunning++;
                        break;

                    case "dirlist":
                        fstools.getdirlist();
                        break;

                    case "rep":
                        echo.init();
                        break;

                    case "ping":
                        ping.init();
                        break;

                    case "nalo":
                        nalo.init();
                        break;

                    case "dig":
                        dig.init();
                        break;

                    case "drvinfo":
                        fstools.drvinfo();
                        break;

                    case "mkfile":
                        fstools.mkfile();
                        break;

                    case "wrtofile":
                        fstools.wrtofile();
                        break;

                    case "clrfile":
                        fstools.clrfile();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Command not recognized. Type help for a list of commands.");
                        break;
                }
            }
        }
    }
}