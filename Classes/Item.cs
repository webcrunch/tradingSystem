namespace TradingSystem;

class Item
{
    public string Name;
    public string Description;

    public TradingStatus TradingLimbo;
    public Item(string name, string description, string statusString)
    {
        Name = name;
        Description = description;

        // Försök konvertera strängen till en enum.
        TradingStatus parsedStatus;

        // TryParse returnerar true om konverteringen lyckas.
        if (Enum.TryParse(statusString, true, out parsedStatus))
        {
            // Om konverteringen lyckades, använd det parsa värdet.
            TradingLimbo = parsedStatus;
        }
        else
        {
            // Om strängen är ogiltig, sätt ett säkert defaultvärde (t.ex. None).
            TradingLimbo = TradingStatus.None;
        }
    }

    public enum TradingStatus
    {
        None,       // No status set
        Trading
    }

}