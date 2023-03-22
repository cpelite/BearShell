﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BärShell.misc
{
    internal class misc
    {
        public static void help()
        {
            Console.WriteLine("\nrep - prompts you to enter something and echoes it back. \nexit - terminates the shell. \ncls - clears the shell. \nping - pings a host. \nnalo - looks up the IP of a Hostname. \ndig - returns DNS-Records. \nmiv - loads MIV (MInimalistic Vim). \ncalc - loads a calculator. \ncat - displays content of a file. ");
        }

        public static void cls()
        {
            //Clears the console
            Console.Clear();
        }

        public static void fscommands()
        {
            Console.WriteLine("dirlist - lists all directories in the root of the filesystem. \ndrvinfo - displays information about the drives. \nmkfile - creates a file in given path. \nwrtofile - writes to a file. \nclrfile - clears the contents of a file. \nmkdir - creates directory. \nrmdir - removes directory.");
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