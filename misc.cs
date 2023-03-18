using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BärShell
{
    internal class misc
    {
        public static void help()
        {
            Console.WriteLine("dirlist - lists all directories in the root of the filesystem. \nrep - prompts you to enter something and echoes it back. \nexit - terminates the shell. \ncls - clears the shell.");
        }

        public static void cls()
        {
            //Clears the console
            Console.Clear();
        }
    }

    internal class echo
    {
        public static void init()
        {
            Console.Write("Enter something to get it echoed back: ");
            string echo = Console.ReadLine();
            Console.WriteLine(echo);
        }
    }
}
