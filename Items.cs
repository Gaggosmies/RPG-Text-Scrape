using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RPGTextToPlugin.jsonClasses;
using System.Collections.Generic;

namespace RPGTextToPlugin
{
    internal class Items
    {
        public static string GetItemsJsonString()
        {
            // todo: fix file location?
            string fileLocationItemsJson = Common.debugLocation(1);

            // check if file is actually found
            if (File.Exists(fileLocationItemsJson))
            {
                return System.IO.File.ReadAllText(fileLocationItemsJson);
            }
            else
            {
                // todo: error handling
                throw new FileNotFoundException("Custom Error Message: Items.json not found at " + Common.debugLocation(1));
            }
        }

        // gets and parses stuff in items.json. If file not found, FileNotFoundException is thrown
        public static JArray GetItemsJsonObjectArray()
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

        public static jsonClasses.Root InitializeItemClass(jsonClasses.Root itemObject)
        {
            itemObject.id = 0;
            itemObject.animationId = 0;
            itemObject.consumable = true;
            itemObject.damage = new jsonClasses.Damage { critical = false, elementId = 0, formula = "", type = 0, variance = 0 };
            itemObject.description = "";
            itemObject.effects = new List<Effect>
            {
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

        public static bool ReadItemsStuff(Common.Globals globals)
        {
            string itemJsonString;
            string outputLocation = System.AppDomain.CurrentDomain.BaseDirectory + "gottenItems.txt";


            itemJsonString = GetItemsJsonString();

            // Deserialize JSON data to object array
            jsonClasses.Root[] items = JsonConvert.DeserializeObject<jsonClasses.Root[]>(itemJsonString);

            // starting from line 1
            int lineNumber = 1;

            using (StreamWriter sw = File.CreateText(outputLocation))
            {
                // Iterate through object array
                foreach (var item in items)
                {
                    // save lineNumber
                    lineNumber++;

                    // handle the first null object
                    if (item == null)
                        continue;

                    // check if name given
                    if (!(string.IsNullOrEmpty(item.name)))
                        sw.WriteLine($"name: {item.name}");
                    else
                        Console.WriteLine($"Missing name on the {lineNumber}");

                    // write only valid variables
                    if (item.id != default(int))
                        sw.WriteLine($"id: {item.id}");
                    if (!(string.IsNullOrEmpty(item.description)))
                        sw.WriteLine($"description: {item.description}");
                    if (item.animationId != default(int))
                        sw.WriteLine($"animationId: {item.animationId}");
                    if (item.consumable != null)
                        sw.WriteLine($"consumable: {item.consumable}");
                    if (item.hitType != default(int))
                        sw.WriteLine($"hitType: {item.hitType}");
                    if (item.iconIndex != default(int))
                        sw.WriteLine($"iconIndex: {item.iconIndex}");
                    if (item.itypeId != default(int))
                        sw.WriteLine($"itypeId: {item.itypeId}");
                    if (!(string.IsNullOrEmpty(item.note)))
                        sw.WriteLine($"note: {item.note}");
                    if (item.occasion != default(int))
                        sw.WriteLine($"occasion: {item.occasion}");
                    if (item.price != default(int))
                        sw.WriteLine($"price: {item.price}");
                    if (item.repeats != default(int))
                        sw.WriteLine($"repeats: {item.repeats}");
                    if (item.scope != default(int))
                        sw.WriteLine($"scope: {item.scope}");
                    if (item.speed != default(int))
                        sw.WriteLine($"speed: {item.speed}");
                    if (item.successRate != default(int))
                        sw.WriteLine($"successRate: {item.successRate}");
                    if (item.tpGain != default(int))
                        sw.WriteLine($"tpGain: {item.tpGain}");

                    // go through classes within class
                    foreach (jsonClasses.Effect effects in item.effects)
                    {
                        if (effects == null)
                        {
                            continue;
                        }

                        if (effects.code != default(int))
                            sw.WriteLine($"\tEffect code: {effects.code}");
                        if (effects.dataId != default(int))
                            sw.WriteLine($"\tEffect dataId: {effects.dataId}");
                        if (effects.value1 != default(int))
                            sw.WriteLine($"\tEffect value1: {effects.value1}");
                        if (effects.value2 != default(int))
                            sw.WriteLine($"\tEffect value2: {effects.value2}");
                    }

                    if (item.damage.critical != null)
                        sw.WriteLine($"\tdamage critical: {item.damage.critical}");
                    if (item.damage.elementId != default(int))
                        sw.WriteLine($"\tdamage elementId: {item.damage.elementId}");
                    if (!(string.IsNullOrEmpty(item.damage.formula)))
                        sw.WriteLine($"\tdamage formula: {item.damage.formula}");
                    if (item.damage.type != default(int))
                        sw.WriteLine($"\tdamage type: {item.damage.type}");
                    if (item.damage.variance != default(int))
                        sw.WriteLine($"\t{item.damage.variance}");
 

                    // start a new line
                    sw.WriteLine();
                }

                sw.Close();
            }

            Console.WriteLine($"Surely there's a lot happenin in {outputLocation}...");
            Console.WriteLine("\n\nPress the any key to continue...");
            System.Console.ReadKey();

            return false;
        }
        public static bool WriteItemsStuff(Common.Globals globals)
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
                sw.Close();
            }


            Console.WriteLine($"Surely there's a lot happenin in {outputLocation}...");
            Console.WriteLine("\n\nPress the any key to continue...");
            System.Console.ReadKey();

            return false;
        }
    }
}
