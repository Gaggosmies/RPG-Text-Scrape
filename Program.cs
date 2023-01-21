﻿using RPGTextToPlugin;

internal class Program
{
    private static void Main(string[] args)
    {
        int command = 999;
        bool txtFileFound = false;
        Common.Globals globals = new Common.Globals();

        globals.greetingText = "Hello!";
        globals.fileLocation = "";

        do // keep doing until cancelled
        {
            txtFileFound = (Texts.CheckIfValidLocation(globals));

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
                    Crafting.DoCraftingStuff(globals);
                    continue;
                }


                if (command == 2)
                {
                    Items.DoItemsStuff(globals);
                    continue;
                }
            }

            if (command == 9)
            {
                Texts.GetTextFile(globals);
                continue;
            }

            globals.greetingText = "Invalid Command";
        } while (command != 0);
    }
}