namespace TradingSystem;

class Item
{
    public string Name;
    public string Description;

    public class Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}