using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace RPGTextToPlugin
{
    internal class Items
    {
        public static bool DoItemsStuff(Common.Globals globals)
        {
            globals.greetingText = "Items stuff (unimplemented for now)";
            Console.WriteLine("Unimplemented for now.");

            Console.WriteLine("\n\nPress any key to continue.");
            System.Console.ReadKey();

            return false;
        }
    }
}
