using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RPGTextToPlugin.jsonClasses;
using System.Collections.Generic;

namespace RPGTextToPlugin
{
    internal class Items
    {
        public const string itemsTxtName = "gottenItems.txt";
        public const string itemsJsonName = "gottenItems.json";
        public const string constName = "Name: ";
        public const string constId = "Id: ";
        public const string constDescription = "Description: ";
        public const string constAnimationId = "AnimationId: ";
        public const string constConsumable = "Consumable: ";
        public const string constHitType = "HitType: ";
        public const string constIconIndex = "IconIndex: ";
        public const string constItypeId = "ItypeId: ";
        public const string constNote = "Note: ";
        public const string constOccasion = "Occasion: ";
        public const string constPrice = "Price: ";
        public const string constRepeats = "Repeats: ";
        public const string constScope = "Scope: ";
        public const string constSpeed = "Speed: ";
        public const string constSuccessRate = "SuccessRate: ";
        public const string constTpGain = "TpGain: ";
        public const string constEffectCode = "Effect Code: ";
        public const string constEffectDataId = "Effect DataId: ";
        public const string constEffectValue1 = "Effect Value1: ";
        public const string constEffectValue2 = "Effect Value2: ";
        public const string constDamageCritical = "Damage Critical: ";
        public const string constDamageElementId = "Damage ElementId: ";
        public const string constDamageFormula = "Damage Formula: ";
        public const string constDamageType = "Damage Type: ";
        public const string constDamageVariance = "Damage Variance: ";

        public static string FindAndTrimFromText(string input, string removeText)
        {
            string output;
            int index = input.IndexOf(removeText);
            if (index >= 0)
            {
                output = input.Remove(index, removeText.Length);
                output = output.Trim();
                return output;
            }
            else 
                return "";
        }

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

        public static void printExampleItem()
        {
            string outputLocation = System.AppDomain.CurrentDomain.BaseDirectory + itemsTxtName;
            using (StreamWriter sw = File.CreateText(outputLocation))
            {
                sw.WriteLine($"#{constName}: My name");
                sw.WriteLine($"#{constId}: 1");
                sw.WriteLine($"#{constDescription}: I am description");
                sw.WriteLine($"#{constAnimationId}: 1");
                sw.WriteLine($"#{constConsumable}: true");
                sw.WriteLine($"#{constHitType}: 1");
                sw.WriteLine($"#{constIconIndex}: 1");
                sw.WriteLine($"#{constItypeId}: 1");
                sw.WriteLine($"#{constNote}: This is note text");
                sw.WriteLine($"#{constOccasion}: 1");
                sw.WriteLine($"#{constPrice}: 150");
                sw.WriteLine($"#{constRepeats}: 1");
                sw.WriteLine($"#{constScope}: 1");
                sw.WriteLine($"#{constSpeed}: 1");
                sw.WriteLine($"#{constSuccessRate}: 1");
                sw.WriteLine($"#{constTpGain}: 1");
                sw.WriteLine($"\t#{constEffectCode}: 1");
                sw.WriteLine($"\t#{constEffectDataId}: 1");
                sw.WriteLine($"\t#{constEffectValue1}: 1");
                sw.WriteLine($"\t#{constEffectValue2}: 1");
                sw.WriteLine($"\t#{constDamageCritical}: true");
                sw.WriteLine($"\t#{constDamageElementId}: 1");
                sw.WriteLine($"\t#{constDamageFormula}: v[1] = 1;");
                sw.WriteLine($"\t#{constDamageType}: 1");
                sw.WriteLine($"\t#{constDamageVariance}: 1");
                sw.WriteLine();
                sw.Close();
            }

            Console.WriteLine($"Printed to {outputLocation}");
            Console.WriteLine("\n\nPress the any key to continue...");
            System.Console.ReadKey();
        }

        public static bool ReadItemsStuff(Common.Globals globals)
        {
            string itemJsonString;
            string outputLocation = System.AppDomain.CurrentDomain.BaseDirectory + itemsTxtName;


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
                        sw.WriteLine($"{constName}{item.name}");
                    else
                        Console.WriteLine($"Missing name on the {lineNumber}");

                    // write only valid variables
                    if (item.id != default(int))
                        sw.WriteLine($"{constId}{item.id}");
                    if (!(string.IsNullOrEmpty(item.description)))
                        sw.WriteLine($"{constDescription}{item.description}");
                    if (item.animationId != default(int))
                        sw.WriteLine($"{constAnimationId}{item.animationId}");
                    if (item.consumable != null)
                        sw.WriteLine($"{constConsumable}{item.consumable}");
                    if (item.hitType != default(int))
                        sw.WriteLine($"{constHitType}{item.hitType}");
                    if (item.iconIndex != default(int))
                        sw.WriteLine($"{constIconIndex}{item.iconIndex}");
                    if (item.itypeId != default(int))
                        sw.WriteLine($"{constItypeId}{item.itypeId}");
                    if (!(string.IsNullOrEmpty(item.note)))
                        sw.WriteLine($"{constNote}{item.note}");
                    if (item.occasion != default(int))
                        sw.WriteLine($"{constOccasion}{item.occasion}");
                    if (item.price != default(int))
                        sw.WriteLine($"{constPrice}{item.price}");
                    if (item.repeats != default(int))
                        sw.WriteLine($"{constRepeats}{item.repeats}");
                    if (item.scope != default(int))
                        sw.WriteLine($"{constScope}{item.scope}");
                    if (item.speed != default(int))
                        sw.WriteLine($"{constSpeed}{item.speed}");
                    if (item.successRate != default(int))
                        sw.WriteLine($"{constSuccessRate}{item.successRate}");
                    if (item.tpGain != default(int))
                        sw.WriteLine($"{constTpGain}{item.tpGain}");

                    // go through classes within class
                    foreach (jsonClasses.Effect effects in item.effects)
                    {
                        if (effects == null)
                        {
                            continue;
                        }

                        if (effects.code != default(int))
                            sw.WriteLine($"\t{constEffectCode} {effects.code}");
                        if (effects.dataId != default(int))
                            sw.WriteLine($"\t{constEffectDataId}{effects.dataId}");
                        if (effects.value1 != default(int))
                            sw.WriteLine($"\t{constEffectValue1}{effects.value1}");
                        if (effects.value2 != default(int))
                            sw.WriteLine($"\t{constEffectValue2}{effects.value2}");
                    }

                    if (item.damage.critical != null)
                        sw.WriteLine($"\t{constDamageCritical}{item.damage.critical}");
                    if (item.damage.elementId != default(int))
                        sw.WriteLine($"\t{constDamageElementId}{item.damage.elementId}");
                    if (!(string.IsNullOrEmpty(item.damage.formula)))
                        sw.WriteLine($"\t{constDamageFormula}{item.damage.formula}");
                    if (item.damage.type != default(int))
                        sw.WriteLine($"\t{constDamageType}{item.damage.type}");
                    if (item.damage.variance != default(int))
                        sw.WriteLine($"\t{constDamageVariance}{item.damage.variance}");


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
            string inputLocation = System.AppDomain.CurrentDomain.BaseDirectory + itemsTxtName;
            string outputLocation = System.AppDomain.CurrentDomain.BaseDirectory + itemsJsonName;
            string[] lines;

            // check if file is actually found
            if (File.Exists(inputLocation))
                lines = System.IO.File.ReadAllLines(inputLocation);
            else
                throw new FileNotFoundException("Custom Error Message: input txt file not found at: " + inputLocation);

            int i = 0;
                
            foreach (string line in lines)
            {
                jsonClasses.Root tempObject = new jsonClasses.Root { };
                InitializeItemClass(tempObject);

                tempObject.id = i;
                
                // todo: add more parameters 



                // turn class object into JSON and add it to the array
                itemJsonArray.Add(JObject.Parse(JsonConvert.SerializeObject(tempObject)));
            }
            

            // write output into a file using RPG maker format
            using (StreamWriter sw = File.CreateText(outputLocation))
            {
                // Wrap in json array, first json object always null in RPG maker
                sw.WriteLine("[");
                sw.WriteLine("null,");

                
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
