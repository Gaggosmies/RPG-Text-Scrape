namespace RPGTextToPlugin
{
    internal class Crafting
    {
        public static bool DoCraftingStuff(Common.Globals globals)
        {
            string[] lines;

            // check if file is actually found
            if (File.Exists(globals.fileLocation))
                lines = System.IO.File.ReadAllLines(globals.fileLocation);
            else
                return false;

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contents of " + globals.fileLocation + " = \n");
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

    }
}
