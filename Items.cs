using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RPGTextToPlugin.jsonClasses;
using System.Collections.Generic;

namespace RPGTextToPlugin
{
    internal class Items
    {
        // gets and parses stuff in items.json. If file not found, FileNotFoundException is thrown
        public static JArray GetItemsJsonArray()
        {
            // todo: fix file location?
            string fileLocationItemsJson = Common.debugLocation(1);

            // check if file is actually found
            if (File.Exists(fileLocationItemsJson))
            {
                string jsonString = System.IO.File.ReadAllText(fileLocationItemsJson);
                return JArray.Parse(jsonString);
            }
            else
            {
                // todo: error handling
                throw new FileNotFoundException("Custom Error Message: Items.json not found at " + Common.debugLocation(1));
            }
        }

        public static jsonClasses.Root InitializeItemClass(jsonClasses.Root itemObject) {
            itemObject.id = 0;
            itemObject.animationId = 0;
            itemObject.consumable = true;
            itemObject.damage = new jsonClasses.Damage { critical = false, elementId = 0, formula = "", type = 0, variance = 0 };
            itemObject.description = "";
            itemObject.effects = new List<Effect> {
                // new jsonClasses.Effect {code = 0, dataId = 0, value1 = 0, value2 = 0},
                // new jsonClasses.Effect {code = 0,dataId = 0, value1 = 0, value2 = 0}
                };
            itemObject.hitType = 0;
            itemObject.iconIndex = 0;
            itemObject.itypeId = 0;
            itemObject.name = "";
            itemObject.note = "";
            itemObject.occasion = 0;
            itemObject.price = 0;
            itemObject.repeats = 0;
            itemObject.scope = 0;
            itemObject.speed = 0;
            itemObject.successRate = 0;
            itemObject.tpGain = 0;

            return itemObject;
        }

        public static bool DoItemsStuff(Common.Globals globals)
        {
            JArray itemJsonArray = new JArray();
            string outputLocation = System.AppDomain.CurrentDomain.BaseDirectory + "gottenItems.json";

            // itemJsonArray = GetItemsJsonArray();


            for (int i = 0; i < 10; i++)
            {
                jsonClasses.Root tempObject = new jsonClasses.Root { };

                InitializeItemClass(tempObject);

                tempObject.id = i;
                // todo: add more parameters 

                string json = JsonConvert.SerializeObject(tempObject);

                //Console.WriteLine(json);

                JObject newTempStuff = JObject.Parse(json);

                itemJsonArray.Add(newTempStuff);
            }

            

            // write output into a file using RPG maker format
            using (StreamWriter sw = File.CreateText(outputLocation))
            {
                // Wrap in json array, first json object always null in RPG maker
                sw.WriteLine("[");
                sw.WriteLine("null,");

                int i = 0;
                foreach (JObject jObject in itemJsonArray.Children<JObject>())
                {
                    i++;
                    sw.Write(jObject.ToString(Newtonsoft.Json.Formatting.None));
                    
                    if (i != itemJsonArray.Count)
                    {
                        sw.WriteLine(",");
                    }
                }

                sw.WriteLine();
                sw.Write("]");
            }


            Console.WriteLine($"Surely there's a lot happenin in {outputLocation}...");
            Console.WriteLine("\n\nPress the any key to continue...");
            System.Console.ReadKey();

            return false;
        }
    }
}
