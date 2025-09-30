// Namespace for the trading system
namespace TradingSystem
{
    // Enum representing the possible statuses of a trade
    enum TradeStatus
    {
        None,       // No status set
        Pending,    // Trade is awaiting action
        Accepted,   // Trade has been accepted
        Denied,     // Trade has been denied
        Canceled    // Trade has been canceled
    }

    // Class representing a trade between two users
    class Trade
    {
        // The user who initiated the trade
        public User Sender;
        // The user who receives the trade request
        public User Receiver;
        // Array containing the items being traded: [0] first index place, from sender, [1] second index place, from receiver
        public Item[] ItemTraded;

        // Current status of the trade
        public TradeStatus Status = TradeStatus.None;

        // Constructor to initialize a trade
        public Trade(User sender, User receiver, Item[] items)
        {
            Sender = sender;
            Receiver = receiver;
            ItemTraded = items;
            Status = TradeStatus.Pending; // Set initial status to Pending
        }

        // Method to accept the trade and exchange items
        public void AcceptTrade()
        {
            // Only allow accepting if trade is pending
            if (Status != TradeStatus.Pending) return;

            // Items to be exchanged
            Item itemFromSender = ItemTraded[0]; // Item sender gives
            Item itemFromReceiver = ItemTraded[1]; // Item receiver gives

            // Remove items from original owners
            Sender.RemoveItem(itemFromSender);
            Receiver.RemoveItem(itemFromReceiver);

            // Add items to new owners
            Sender.AddItem(itemFromReceiver);
            Receiver.AddItem(itemFromSender);

            // Update trade status
            Status = TradeStatus.Accepted;

            // Notify both users about the accepted trade
            string senderMessage = $"Your trade with {Receiver.Email} has been accepted. You received item: {itemFromReceiver.Name}.";
            string receiverMessage = $"You accepted the trade with {Sender.Email}. You received item: {itemFromSender.Name}.";
            Sender.message.Add(senderMessage);
            Receiver.message.Add(receiverMessage);
        }

        // Method to deny the trade
        public void DenyTrade()
        {
            // Only allow denying if trade is pending
            if (Status != TradeStatus.Pending) return;
            Item itemFromSender = ItemTraded[0];
            Item itemFromReceiver = ItemTraded[1];
            itemFromReceiver.TradingLimbo = Item.TradingStatus.None;
            itemFromSender.TradingLimbo = Item.TradingStatus.None;
            // Update trade status
            Status = TradeStatus.Denied;

            // Notify both users about the denied trade
            string senderMessage = $"Your trade with {Receiver.Email} has been denied.";
            string receiverMessage = $"You denied the trade with {Sender.Email}.";
            Sender.message.Add(senderMessage);
            Receiver.message.Add(receiverMessage);
        }
    }
}