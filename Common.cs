using static RPGTextToPlugin.Common;

namespace RPGTextToPlugin
{
    internal class Common
    {
        // static class to hold global variables, etc.
        public class Globals
        {
            public string greetingText = "Hi";
            public string? fileLocation = "default";
        }

        public static string debugLocation(int giveThisLocation)
        {
            // giveThisLocation:
            // 1: Items
            // 2: Armors

            string debugTxtLocation = System.AppDomain.CurrentDomain.BaseDirectory + "debugLocations.txt";
            string[] lines;
            int i = 0;

            // check if file is actually found
            if (File.Exists(debugTxtLocation))
                lines = System.IO.File.ReadAllLines(debugTxtLocation);
            else
                return "";
                
            foreach (string line in lines)
            {
                i++;
                if (i == giveThisLocation)
                {
                    return line.Trim('"');
                }
            }

            return "";
        }
    }
}
