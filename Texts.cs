using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace RPGTextToPlugin
{
    internal class Texts
    {
        public static bool GetTextFile(Common.Globals globals)
        {
            bool gotFile = false;

            Console.WriteLine("Give location (either c:\\[path] or just the name if in same folder) (.txt included)\n");
            Console.WriteLine("Example 1: \tC:\\temp\\test.txt\n\t\t^ (file can be anywhere)\n");
            Console.WriteLine("Example 2: \ttest.txt\n\t\t^ (file in same folder as this software)\n");

            Console.Write("Location: ");

            try
            {
                globals.fileLocation = Console.ReadLine();

                gotFile = true;
            }
            catch (Exception e)
            {
                globals.greetingText = ("Error: " + e);
                globals.fileLocation = "";
                return false;
            }

            if (globals.fileLocation != null)
            {
                if (globals.fileLocation.Contains(":\\") == false)
                {
                    string tempFileLocation = globals.fileLocation;
                    globals.fileLocation = System.AppDomain.CurrentDomain.BaseDirectory + tempFileLocation;
                }
            }

            return gotFile;
        }

        public static bool CheckIfValidLocation(Common.Globals globals)
        {
            bool isValid = false;

            // emtpy file location
            if (globals.fileLocation == "")
            {
                return false;
            }


            if (File.Exists(globals.fileLocation))
            {
                globals.greetingText = ($"File {globals.fileLocation} found!");
                isValid = true;
            }
            else
            {
                globals.greetingText = ($"File {globals.fileLocation} does not exist!");
                return false;
            }

            // if has ".txt"
            if (globals.fileLocation.Contains(".txt"))
                isValid = true;
            else
            {
                globals.greetingText = ("File type invalid!");
                return false;
            }

            return isValid;
        }
    }
}
