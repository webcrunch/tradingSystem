namespace TradingSystem;

class Item
{
    public string Name;
    public string Description;

    public TradingStatus tradingLimbo;

    public Item(string name, string description)
    {
        Name = name;
        Description = description;
        tradingLimbo = TradingStatus.None;
    }

    public enum TradingStatus
    {
        None,       // No status set
        Trading
    }

}