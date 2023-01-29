using RPGTextToPlugin;

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

            // todo: fix txt file checkings
            if (txtFileFound)
            {
                Console.WriteLine("1. Crafting");
                
            }
            Console.WriteLine("2. Write Items");
            Console.WriteLine("3. Read Items");
            Console.WriteLine("4. Print item example");

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
                switch (command){
                    case 1:
                        Crafting.DoCraftingStuff(globals);
                        break;

                    default: 
                        globals.greetingText = "Invalid Command";
                        break;
                }
            }
            
            switch (command){
                    case 2:
                        Items.WriteItemsStuff(globals);
                        break;

                    case 3:
                        Items.ReadItemsStuff(globals);
                        break;

                    case 4:
                        Items.printExampleItem();
                        break;

                    case 9:
                        Texts.GetTextFile(globals);
                        break;

                    default: 
                        globals.greetingText = "Invalid Command";
                        break;
            }

        } while (command != 0);
    }
}