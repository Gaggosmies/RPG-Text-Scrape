using System.IO;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    // static class to hold global variables, etc.
    public class Globals
    {
        public string greetingText = "Hi";
        public string? fileLocation = "default";
    }


    private static void Main(string[] args)
    {
        int command = 999;
        bool txtFileFound = false;
        Globals globals = new Globals();

        globals.greetingText = "Hello!";
        globals.fileLocation = "";

        do // keep doing until cancelled
        {
            txtFileFound = (CheckIfValidLocation(globals));

            Console.Clear();
            Console.WriteLine(globals.greetingText);
            Console.WriteLine();
            Console.WriteLine("Gaggo's cool software");
            Console.WriteLine("Please give command");

            Console.WriteLine();

            if (txtFileFound)
            {
                Console.WriteLine("1. Crafting");
                Console.WriteLine("2. Items");
            }

            Console.WriteLine("9. Give text file location");
            Console.WriteLine("0. Cancel");

            Console.Write("\n\nCommand: ");

            try
            {
                command = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                globals.greetingText = "Please give number, error: " + e;
                command = 999;
                continue;
            }

            Console.Clear();

            if (txtFileFound)
            {
                if (command == 1)
                {
                    DoCraftingStuff(globals);
                    continue;
                }


                if (command == 2)
                {
                    DoItemsStuff(globals);
                    continue;
                }
            }

            if (command == 9)
            {
                GetTextFile(globals);
                continue;
            }

            globals.greetingText = "Invalid Command";
        } while (command != 0);
    }

    public static bool DoCraftingStuff(Globals globals)
    {
        string[] lines;

        // check if file is actually found
        if (File.Exists(globals.fileLocation))
            lines = System.IO.File.ReadAllLines(globals.fileLocation);
        else
            return false;

        // Display the file contents by using a foreach loop.
        System.Console.WriteLine("Contents of "+ globals.fileLocation +" = \n");
        System.Console.WriteLine("---------------------------------------------------");
        foreach (string line in lines)
        {
            // Use a tab to indent each line of the file.
            Console.WriteLine("\t" + line);
        }
        System.Console.WriteLine("---------------------------------------------------");

        // Keep the console window open in debug mode.
        Console.WriteLine("\n\nPress any key to continue.");
        System.Console.ReadKey();
        return false;
    }

    public static bool DoItemsStuff(Globals globals)
    {
        globals.greetingText = "Items stuff (unimplemented for now)";
        Console.WriteLine("Unimplemented for now.");

        Console.WriteLine("\n\nPress any key to continue.");
        System.Console.ReadKey();

        return false;
    }

    public static bool GetTextFile(Globals globals)
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

        if(globals.fileLocation != null)
        {
            if (globals.fileLocation.Contains(":\\") == false)
            {
                string tempFileLocation = globals.fileLocation;
                globals.fileLocation  = System.AppDomain.CurrentDomain.BaseDirectory + tempFileLocation;
            }
        }

        return gotFile;
    }

    private static bool CheckIfValidLocation(Globals globals)
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