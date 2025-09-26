namespace TradingSystem;

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
        Status = TradeStatus.Pending; // Status sätts korrekt här!
    }

    public void AcceptTrade()
    {
        if (Status != TradeStatus.Pending) return;

        // Föremålen som byts:
        Item itemFromSender = ItemTraded[0]; // Detta är det föremål mottagaren FÅR
        Item itemFromReceiver = ItemTraded[1]; // Detta är det föremål avsändaren FÅR

        // 1. Ta bort föremålen från de ursprungliga ägarna
        Sender.RemoveItem(itemFromSender);
        Receiver.RemoveItem(itemFromReceiver);

        // 2. Lägg till föremålen till de nya ägarna
        Sender.AddItem(itemFromReceiver);
        Receiver.AddItem(itemFromSender);

        // 3. Uppdatera status
        Status = TradeStatus.Accepted;

        // 4. Skicka meddelanden till båda användarna
        string senderMessage = $"Your trade with {Receiver.Email} has been accepted. You received item: {itemFromReceiver.Name}.";
        string receiverMessage = $"You accepted the trade with {Sender.Email}. You received item: {itemFromSender.Name}.";
        Sender.message.Add(senderMessage);
        Receiver.message.Add(receiverMessage);
    }

    public void DenyTrade()
    {
        if (Status != TradeStatus.Pending) return;

        Status = TradeStatus.Denied;

        // Skicka meddelanden till båda användarna
        string senderMessage = $"Your trade with {Receiver.Email} has been denied.";
        string receiverMessage = $"You denied the trade with {Sender.Email}.";
        Sender.message.Add(senderMessage);
        Receiver.message.Add(receiverMessage);
    }
}