using TradingSystem;

enum TradeStatus

{
    None,
    Pending,
    Accepted,
    Denied,
    Canceled
}

class Trade
{
    public string Sender;
    public string Receiver;
    public Item[] ItemTraded;

    public TradeStatus Status = TradeStatus.None;
    public Trade(string sender, string receiver, Item[] items)
    {
        Sender = sender;
        Receiver = receiver;
        ItemTraded = items;
        Status = TradeStatus.Pending;
    }
}