namespace RPGTextToPlugin.jsonClasses
{
    public class ItemClass
    {
        public List<Root> myItemClass { get; set; }
    }
    public class Damage
    {
        public bool critical { get; set; }
        public int elementId { get; set; }
        public string? formula { get; set; }
        public int type { get; set; }
        public int variance { get; set; }
    }

    public class Effect
    {
        public int code { get; set; }
        public int dataId { get; set; }
        public int value1 { get; set; }
        public int value2 { get; set; }
    }

    public class Root
    {
        public int id { get; set; }
        public int animationId { get; set; }
        public bool consumable { get; set; }
        public Damage? damage { get; set; }
        public string? description { get; set; }
        public List<Effect>? effects { get; set; }
        public int hitType { get; set; }
        public int iconIndex { get; set; }
        public int itypeId { get; set; }
        public string? name { get; set; }
        public string? note { get; set; }
        public int occasion { get; set; }
        public int price { get; set; }
        public int repeats { get; set; }
        public int scope { get; set; }
        public int speed { get; set; }
        public int successRate { get; set; }
        public int tpGain { get; set; }
    }
}
