// Namespace for the trading system
namespace TradingSystem
{

    /// <summary>
    /// Possible states of a trade.
    /// We are using this for status if the trade object
    /// </summary>

    enum TradeStatus
    {
        None,       // No status set
        Pending,    // Trade is awaiting action
        Accepted,   // Trade has been accepted
        Denied,     // Trade has been denied
        Canceled    // Trade has been canceled
    }



    // <summary>
    /// Represents a trade between two users, including items and status.
    /// </summary>
    class Trade
    {
        /// <summary>
        /// The user who initiated the trade.
        /// </summary>
        public User Sender;

        /// <summary>
        /// The user who receives the trade request.
        /// </summary>
        public User Receiver;

        /// <summary>
        /// Items being traded: index 0 = from sender, index 1 = from receiver.
        /// </summary>
        public Item[] ItemTraded;

        /// <summary>
        /// Current status of the trade.
        /// </summary>
        public TradeStatus Status;

        /// <summary>
        /// Initializes a new trade between two users with given items and status.
        /// Status string is parsed into <see cref="TradeStatus"/> (case-insensitive).
        /// Defaults to <see cref="TradeStatus.None"/> if parsing fails.
        /// </summary>

        // Constructor to initialize a trade
        public Trade(User sender, User receiver, Item[] items, string status)
        {
            Sender = sender;
            Receiver = receiver;
            ItemTraded = items;


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
            TradeStatus parsedStatus;
            bool success = Enum.TryParse(status, true, out parsedStatus);
            Status = success ? parsedStatus : TradeStatus.None;
        }
        /// <summary>
        /// Accepts the trade, exchanges items between users, 
        /// updates status to <see cref="TradeStatus.Accepted"/>, 
        /// and notifies both users.
        /// </summary>
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
            Sender.Messages.Add(senderMessage);
            Receiver.Messages.Add(receiverMessage);
        }

        /// <summary>
        /// Denies the trade, resets item states, 
        /// updates status to <see cref="TradeStatus.Denied"/>, 
        /// and notifies both users.
        /// </summary>
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
            Sender.Messages.Add(senderMessage);
            Receiver.Messages.Add(receiverMessage);
        }
    }
}