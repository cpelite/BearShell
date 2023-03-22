using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace BärShell.tools
{
    public class fstools
    {
        public static void getdirlist()
        {
            try
            {
                //Get path
                Console.WriteLine("Please enter a path: ");
                string path = Console.ReadLine();
                string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
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

        public static void drvinfo()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                Console.WriteLine("Drive {0}", drive.Name);
                Console.WriteLine(" Drive type: {0}", drive.DriveType);
                if (drive.IsReady == true)
                {
                    Console.WriteLine(" Volume label: {0}", drive.VolumeLabel);
                    Console.WriteLine(" File system: {0}", drive.DriveFormat);
                    Console.WriteLine(
                    "  Available space to current user:{0, 15} bytes",
                    drive.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        drive.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        drive.TotalSize);
                }
            }
        }

        public static void mkfile()
        {
            //Path of the file to be created. Path is given by user!
            Console.WriteLine("Enter the path where the file should be created: ");
            string filepath = Console.ReadLine();

            //Create file at filepath
            FileStream fs = File.Create(filepath);

            //check if file is created at specified path
            if (File.Exists(filepath))
            {
                Console.WriteLine("File has been created.");
            }

            else
            {
                Console.WriteLine("File has not been created.");
            }
        }

        public static void wrtofile()
        {
            //Path
            Console.WriteLine("Please enter the path to the file to which text should be written: ");
            string filewrpath = Console.ReadLine();

            //Get text to be written
            Console.WriteLine("Please enter the text which should be written to the file: ");
            string ttbw = Console.ReadLine();

            //Write!
            using (StreamWriter sw = File.AppendText(filewrpath))
            {
                sw.WriteLine(ttbw);
            }

        }

        public static void clrfile()
        {
            //Get path
            Console.WriteLine("Please enter the path to the file which shall be cleaned: ");
            string clrfilepath = Console.ReadLine();

            //clear file
            File.WriteAllText(clrfilepath, "");
        }

        public static void mkdir()
        {
            //Get path
            Console.WriteLine("Please enter the path where the new directory should be created: ");
            string mkpath = Console.ReadLine();

            //Create directory
            DirectoryInfo directory = Directory.CreateDirectory(mkpath);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(mkpath));
        }

        public static void rmdir()
        {
            //Get path
            Console.WriteLine("Please enter the path of the folder that should be deleted: ");
            string deldir = Console.ReadLine();

            //Remove directory
            Directory.Delete(deldir);
            Console.WriteLine("Directory " + deldir + " has been deleted.");
        }

        public static void cat()
        {
            //Get path to file
            Console.WriteLine("Please enter the path to the file: ");
            string path = Console.ReadLine();

            //Read the file as one string.
            string text = File.ReadAllText(path);

            //Display contents of file.
            Console.WriteLine("The content of " + path + " is: ");
            Console.WriteLine(text);
        }
    }
}
