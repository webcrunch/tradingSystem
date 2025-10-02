namespace TradingSystem;
/// <summary>
/// Represents an item in the trading system.
/// Each item has a name, description, and a trading status.
/// </summary>
class Item
{
    /// <summary>
    /// The name of the item.
    /// </summary>
    public string Name;
    /// <summary>
    /// A short description of the item.
    /// </summary>
    public string Description;
    /// <summary>
    /// The current trading status of the item.
    /// </summary>
    public TradingStatus TradingLimbo;

    /// <summary>
    /// Initializes a new <see cref="Item"/> with the given name, description, and status string.
    /// The status string is parsed into <see cref="TradingStatus"/> (case-insensitive).
    /// Defaults to <see cref="TradingStatus.None"/> if parsing fails.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="description">The description of the item.</param>
    /// <param name="statusString">The trading status as a string (e.g., "Trading").</param>
    public Item(string name, string description, string statusString)
    {
        Name = name;
        Description = description;
        /// <summary>
        /// Because i am using strings in the saving to file we need to convert the string into number
        /// The enum has also a tryparse. What it does it takes the value. And in this example it will be a string. 
        /// We can say it is None. It tries to find the value in the enum and convert it into a index. 
        /// Here are the syntax for the enum. 
        /// After that i am using a iternary to say if i get a enum we will set that to status otherwise i user the None status
        /// bool success = Enum.TryParse<TEnum>(
        /// string value,          // value to convert
        ///bool ignoreCase,       // if i want to ignore upper/smaller case. 
        ///out TEnum result       // output parameter that will get the enum value
        ///);
        /// </summary>
        TradingStatus parsedStatus;
        bool success = Enum.TryParse(statusString, true, out parsedStatus);
        TradingLimbo = success ? parsedStatus : TradingStatus.None;

        // Old version, same functionality but with if else statemen. We do that with iternary instead// // Försök konvertera strängen till en enum.
        // TradingStatus parsedStatus;

        // // TryParse returnerar true om konverteringen lyckas.
        // if (Enum.TryParse(statusString, true, out parsedStatus))
        // {
        //     // Om konverteringen lyckades, använd det parsa värdet.
        //     TradingLimbo = parsedStatus;
        // }
        // else
        // {
        //     // Om strängen är ogiltig, sätt ett säkert defaultvärde (t.ex. None).
        //     TradingLimbo = TradingStatus.None;
        // }
    }

    /// <summary>
    /// Defines the possible trading states of an item.
    /// </summary>
    public enum TradingStatus
    {
        /// <summary>
        /// No status set (default).
        /// </summary>
        None,

        /// <summary>
        /// Item is currently marked for trading.
        /// </summary>
        Trading
    }

}