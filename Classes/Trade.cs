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
    public User Sender;
    public User Receiver;
    public Item[] ItemTraded;

    public TradeStatus Status = TradeStatus.None;
    public Trade(User sender, User receiver, Item[] items)
    {
        Sender = sender;
        Receiver = receiver;
        ItemTraded = items;
        Status = TradeStatus.Pending;
    }
}