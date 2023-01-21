using Newtonsoft.Json.Linq;
using RPGTextToPlugin.jsonClasses;
using System.Text.Json.Serialization;

namespace RPGTextToPlugin
{
    internal class Items
    {
        public static bool DoItemsStuff(Common.Globals globals)
        {
            string fileLocationItemsJson = Common.debugLocation(1);
            JArray itemJsonArray;

            // check if file is actually found
            if (File.Exists(fileLocationItemsJson))
            {
                string jsonString = System.IO.File.ReadAllText(fileLocationItemsJson);
                itemJsonArray = JArray.Parse(jsonString);
            }
            else
            {
                return false;
            }



            return false;
        }
    }
}
