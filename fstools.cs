using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BärShell
{
    public class fstools
    {
        public static void getdirlist()
        {
            try
            {
                string[] dirs = Directory.GetDirectories(@"c:\", "*", SearchOption.TopDirectoryOnly);
                Console.WriteLine("The following directories exist. There are {0} directories.", dirs.Length);
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}
