// Todos for the trading system:
// A user needs to be able to register an account  ---- klart
// A user needs to be able to log out. ----- Klart
// A user needs to be able to log in. ----- Klart
// A user needs to be able to upload information about the item they wish to trade. ---- Klart


// A user needs to be able to browse a list of other users items. ---- Klart

// Refactor the need above . ---- Klart 
// A user needs to be able to request a trade for other users items. ---- Klart
// A user needs to be able to see a list of their sent trade requests. ---- Klart
// A user needs to be able to cancel a sent trade request. ---- Klart


// A user needs to be able to browse trade requests.

// A user needs to be able to accept a trade request.
// A user needs to be able to deny a trade request. 

// A user needs to be able to browse completed requests.

/// only accept/deny the user is the recepter. ---- Klart
/// only cancel the user is the sender. ---- Klart

using TradingSystem;
List<User> users = new List<User>();
List<Item> items = new List<Item>();
List<Trade> trades = new List<Trade>();
bool continueRunning = true;
User? active_user = null;


// Creating a dump user and item for testing
users.Add(new User("test", "test")); // Default user for testing
active_user = users[0];
users.Add(new User("albert", "beteman")); // Another  user for testing
users.Add(new User("jarl", "jarleman")); // Another  user for testing
active_user.AddItem(new Item("Böcker", "32 stycken nalle puh böcker")); // Default item for testing
active_user.AddItem(new Item("handskar", "2 par elefanthanskar")); // Default item for testing
active_user = null; // Log out the test user
active_user = users[1];
active_user.AddItem(new Item("Abombs", "100 stora atombomber")); // Default item for testing
active_user.AddItem(new Item("skor", "2 par elefantskor")); // Default item for testing
active_user = null; // Log out the test user
active_user = users[2];
active_user.AddItem(new Item("Bilar", "32 stycken leksaksbilar")); // Default item for testing
active_user.AddItem(new Item("dator", "en macbook pro 2020"));
active_user = null; // Log out the test user

while (continueRunning)
{
    Extra.MainMenu(active_user?.Email ?? "No user logged in");

    switch (Console.ReadLine() ?? "")
    {
        case "1":
            bool loginRunning = true;
            while (loginRunning)
            {
                Extra.AddLogin();
                switch (Console.ReadLine() ?? "")
                {
                    case "1":
                        Console.Write("Enter username: ");
                        string? inputUsername = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string? inputPassword = Console.ReadLine();
                        User? foundUser = users.Find(user => user.TryLogin(inputUsername ?? "", inputPassword ?? ""));
                        if (foundUser != null)
                        {
                            active_user = foundUser;
                            loginRunning = false;
                            Extra.DisplaySuccesText("Login successful.");
                        }
                        else
                        {
                            Extra.DisplayAlertText("Login failed. Incorrect username or password.");
                        }
                        Thread.Sleep(3000);
                        break;
                    case "2":
                        if (active_user != null)
                        {
                            active_user = null;
                            Extra.DisplaySuccesText("Logged out successfully.");
                            Thread.Sleep(3000);
                        }
                        else
                        {
                            Extra.DisplayAlertText("No user is currently logged in.");
                            Thread.Sleep(3000);
                            loginRunning = false;
                            break;
                        }
                        break;
                }
            }
            break;
        case "2":
            bool accountRunning = true;
            while (accountRunning)
            {
                Extra.Accountmenu();
                switch (Console.ReadLine() ?? "")
                {
                    case "1":
                        Console.WriteLine("Create account selected.");
                        Console.Write("Enter username for the account: ");
                        string? CreateInputUsername = Console.ReadLine();
                        Console.Write("Enter password for the account: ");
                        string? CreateInputPassword = Console.ReadLine();
                        users.Add(new User(CreateInputUsername ?? "", CreateInputPassword ?? ""));
                        Extra.DisplaySuccesText("Account created successfully.");
                        Thread.Sleep(3000);
                        break;
                    case "3":
                        accountRunning = false;
                        break;
                }
            }
            break;
        case "3":
            if (active_user == null)
            {
                Extra.DisplayAlertText("No user is currently logged in.");
                Thread.Sleep(3000);
                break;
            }
            else
            {
                bool itemRunning = true;

                while (itemRunning)
                {

                    Extra.itemMenu("Item");
                    switch (Console.ReadLine() ?? "")
                    {
                        case "1":
                            Console.WriteLine("Adding new item selected.");
                            Console.Write("Enter item name: ");
                            string itemName = Console.ReadLine() ?? "";
                            Console.Write("Enter item description: ");
                            string itemDescription = Console.ReadLine() ?? "";
                            items.Add(new Item(itemName, itemDescription));
                            Extra.DisplaySuccesText("Item added successfully.");
                            active_user?.AddItem(new Item(itemName, itemDescription));
                            Thread.Sleep(3000);
                            break;
                        case "2":
                            Console.WriteLine("Your items:");
                            active_user?.ShowItems();
                            break;
                        case "3":
                            Console.WriteLine("Showing all others items:");
                            foreach (User user in users)
                            {
                                if (user == active_user) continue; // Skip the active user's items
                                user.ShowItems();
                            }
                            break;
                        case "4":
                            itemRunning = false;
                            break;
                    }
                }
            }
            break;
        case "4":
            if (active_user == null)
            {
                Extra.DisplayAlertText("No user is currently logged in.");
                Thread.Sleep(3000);
                break;
            }
            else
            {
                bool tradeRunning = true;
                while (tradeRunning)
                {
                    Extra.Trademenu();
                    switch (Console.ReadLine() ?? "")
                    {
                        case "1":
                            Console.WriteLine("Request trade selected.");
                            Extra.Displayusers(users, active_user);
                            Console.WriteLine("Select a user to trade with:");
                            if (int.TryParse(Console.ReadLine(), out int userIndex) && userIndex > 0 && userIndex <= users.Count && users[userIndex - 1] != active_user)
                            {
                                User receiver = users[userIndex - 1];
                                Console.WriteLine("");
                                Console.WriteLine($"Selected user: {receiver.Email}");
                                Console.WriteLine("");
                                Console.WriteLine("Select an item to trade from your items:");
                                active_user.ShowItems();
                                Console.Write("Enter the name of the item you want to trade: ");
                                Item? itemToTrade = active_user.FindItem(Console.ReadLine() ?? "");
                                if (itemToTrade == null)
                                {
                                    Extra.DisplayAlertText("Item not found in your items.");
                                    Thread.Sleep(3000);
                                    break;
                                }
                                Console.WriteLine("Select an item to receive from the other user's items:");
                                receiver.ShowItems();
                                Console.Write("Enter the name of the item you want to receive: ");
                                Item? itemToRecive = receiver.FindItem(Console.ReadLine() ?? "");
                                if (itemToRecive == null)
                                {
                                    Extra.DisplayAlertText("Item not found in the other user's items.");
                                    Thread.Sleep(3000);
                                    break;
                                }
                                Item[] newTradedItems = new Item[2];
                                newTradedItems[0] = itemToTrade;
                                newTradedItems[1] = itemToRecive;

                                trades.Add(new Trade(active_user, receiver, newTradedItems));
                                string senderMessage = $"You have sent a trade request to {receiver.Email} for item {itemToRecive.Name}.";
                                string receiverMessage = $"{active_user.Email} has requested to trade their item {itemToTrade.Name} for your item {itemToRecive.Name}.";
                                active_user.message.Add(senderMessage);
                                receiver.message.Add(receiverMessage);
                                Extra.DisplaySuccesText("Trade request sent successfully.");
                            }
                            else
                            {
                                Extra.DisplayAlertText("Invalid user selection.");
                            }
                            Thread.Sleep(3000);
                            break;
                        case "2":
                            active_user.displayMessage();
                            Thread.Sleep(3000);
                            break;
                        case "3":
                            Extra.ShowMenyTradeHandling();
                            switch (Console.ReadLine() ?? "")
                            {
                                case "1":
                                    List<Trade> sentTrades = trades.Where(t => t.Sender == active_user && t.Status != TradeStatus.Canceled).ToList();
                                    if (sentTrades.Count == 0)
                                    {
                                        Extra.DisplayAlertText("No sent trade requests.");
                                        Thread.Sleep(3000);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sent trade requests:");
                                        for (int i = 0; i < sentTrades.Count; i++)
                                        {
                                            var trade = sentTrades[i];
                                            // Utskrift av detaljer
                                            Console.WriteLine($"{i + 1}. Status: {trade.Status} | To: {trade.Receiver.Email} | You offer: {trade.ItemTraded[0].Name} | You want: {trade.ItemTraded[1].Name}");
                                        }
                                        Thread.Sleep(3000);
                                    }
                                    Console.WriteLine("Do you want to cancel a sent trade request? (y/n)");
                                    string? cancelChoice = Console.ReadLine();
                                    if (cancelChoice?.ToLower() == "y")
                                    {
                                        Console.Write("Enter the number of the trade to cancel: ");
                                        if (int.TryParse(Console.ReadLine(), out int cancelIndex) && cancelIndex > 0 && cancelIndex <= sentTrades.Count)
                                        {
                                            Trade tradeToCancel = sentTrades[cancelIndex - 1];
                                            if (tradeToCancel.Status == TradeStatus.Pending)
                                            {
                                                tradeToCancel.Status = TradeStatus.Canceled;
                                                string senderMessage = $"You have canceled the trade request to {tradeToCancel.Receiver.Email}.";
                                                string receiverMessage = $"{active_user.Email} has canceled the trade request.";
                                                active_user.message.Add(senderMessage);
                                                tradeToCancel.Receiver.message.Add(receiverMessage);
                                                Extra.DisplaySuccesText("Trade request canceled.");
                                            }
                                            else
                                            {
                                                Extra.DisplayAlertText("Only pending trades can be canceled.");
                                            }
                                        }
                                        else
                                        {
                                            Extra.DisplayAlertText("Invalid trade selection.");
                                        }
                                        Thread.Sleep(3000);
                                    }
                                    break;
                                case "2":

                                    List<Trade> recivedTrades = trades.Where(t => t.Receiver.Email == active_user.Email && t.Status == TradeStatus.Pending).ToList();

                                    if (recivedTrades.Count == 0)
                                    {
                                        Extra.DisplayAlertText("No pending trade requests.");
                                        Thread.Sleep(3000);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Pending trade requests:");
                                        for (int i = 0; i < recivedTrades.Count; i++)
                                        {
                                            Trade trade = recivedTrades[i];

                                            Console.WriteLine($"{i + 1}. Status: {trade.Status} | From: {trade.Sender.Email} | They offer: {trade.ItemTraded[0].Name} | They want: {trade.ItemTraded[1].Name}");
                                        }
                                        Console.Write("Select a trade to handle (enter number): ");
                                        Thread.Sleep(2000);
                                    }
                                    break;
                                case "3":
                                    break;
                                case "4":
                                    break;
                                case "5":
                                    tradeRunning = false;
                                    Thread.Sleep(3000);
                                    break;
                            }

                            // Hantera mottagna trade requests
                            // Hämta alla trades där den inloggade användaren är mottagare och status är Pending


                            // var userTrades = trades.Where(t => t.Receiver == active_user && t.Status == TradeStatus.Pending).ToList();
                            // if (userTrades.Count == 0)
                            // {
                            //     Extra.DisplayAlertText("No pending trade requests.");
                            //     Thread.Sleep(3000);
                            // }
                            // else
                            // {
                            //     Console.WriteLine("Pending trade requests:");
                            //     for (int i = 0; i < userTrades.Count; i++)
                            //     {
                            //         var trade = userTrades[i];
                            //         // Utskrift av detaljer
                            //         Console.WriteLine($"{i + 1}. Status: {trade.Status} | From: {trade.Sender.Email} | They offer: {trade.ItemTraded[0].Name} | They want: {trade.ItemTraded[1].Name}");
                            //     }

                            //     // ... (Hantering av Accept/Deny fortsätter här)
                            //     Console.Write("Select a trade to handle (enter number): ");
                            //     if (int.TryParse(Console.ReadLine(), out int tradeIndex) && tradeIndex > 0 && tradeIndex <= userTrades.Count)
                            //     {
                            //         var selectedTrade = userTrades[tradeIndex - 1];
                            //         Console.WriteLine("1. Accept Trade");
                            //         Console.WriteLine("2. Deny Trade");
                            //         Console.Write("Enter your choice: ");
                            //         string? choice = Console.ReadLine();

                            //         if (choice == "1")
                            //         {
                            //             selectedTrade.AcceptTrade();
                            //             Extra.DisplaySuccesText("Trade accepted and items exchanged.");
                            //         }
                            //         else if (choice == "2")
                            //         {
                            //             selectedTrade.DenyTrade();
                            //             Extra.DisplaySuccesText("Trade denied.");
                            //         }
                            //         else
                            //         {
                            //             Extra.DisplayAlertText("Invalid choice.");
                            //         }
                            //     }
                            //     else
                            //     {
                            //         Extra.DisplayAlertText("Invalid trade selection.");
                            //     }
                            // }
                            // Thread.Sleep(3000); // Långare delay här kan vara bra

                            break;
                        case "4":
                            tradeRunning = false;
                            Thread.Sleep(3000);
                            break;
                    }
                }
                break;
            }
        case "7":
            Console.WriteLine("Exiting...");
            continueRunning = false;
            break;
    }
}