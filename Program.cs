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


// A user needs to be able to browse trade requests. --- Klart

// A user needs to be able to accept a trade request. --- Klart
// A user needs to be able to deny a trade request. --- Klart

// A user needs to be able to browse completed requests. --- Klart

/// only accept/deny the user is the recepter. ---- Klart
/// only cancel the user if the sender. ---- Klart

// I am usign the TradingSystem namespace.
using TradingSystem;
//  For handle the data for the users and the items and trades i am creating three lists.
// The dataformat for each list is a from User class, Item class and Trade class.
// i calling them users, items and trades.
List<User> users = new List<User>();
List<Item> items = new List<Item>();
List<Trade> trades = new List<Trade>();

// This bool is for controlling the main loop of the program.
bool continueRunning = true;
// This is for keeping track of the currently logged-in user. 
// default value is null, meaning no user is logged in.
User? active_user = null;

// _______ dummy data for testing purposes _________
// Creating a dump user and item for testing
// creating three users and two items for each user.
// This is just for testing purposes. and to be able to see how the program works.
users.Add(new User("test", "test")); // User1 for testing
users.Add(new User("albert", "beteman")); // User2 for testing
users.Add(new User("jarl", "jarleman")); // User3 user for testing
// Log in and create some items for the first user
active_user = users[0]; // Log in the test user
active_user.AddItem(new Item("Böcker", "32 stycken nalle puh böcker")); // Items for testing
active_user.AddItem(new Item("handskar", "2 par elefanthanskar")); // Items for testing
active_user = null; // Log out the test user
// Creating dummy data and log in for the second user
active_user = users[1]; // Log in the test user
active_user.AddItem(new Item("Abombs", "100 stora atombomber")); // Items for testing
active_user.AddItem(new Item("skor", "2 par elefantskor")); // Items for testing
active_user = null; // Log out the test user
// Creating dummy data and log in for the third user
active_user = users[2]; // Log in the test user
active_user.AddItem(new Item("Bilar", "32 stycken leksaksbilar")); // Items for testing
active_user.AddItem(new Item("dator", "en macbook pro 2020")); // Items for testing
active_user = null; // Log out the test user
// _______ end of dummy data for testing purposes _________

// i have decided to create a class named Extra for handling the menu system.
// The class is static because i do not need to create an instance of it.
// it is mostly for displaying the menus and some helper functions. 
// And to try to keep the Program.cs file clean.


// to keep a live loop of the program until the user decides to exit.
// I have choosen to build the logic for the menu system with two layers. 
// Login - Account - Item - Trade - Exit
// Login - login - log out - go back to main menu
// Account - create account - go back to main menu
// Item - add item - show my items - show all other users items - go back to main menu
// Trade - request trade - message of trades - handle trades - go back to main menu
// I have tried to keep it simple and easy to understand for the user. Still some improvements can be made. 
// Especially in the trade handling menu to handle exiting in a user input face.
// Each menu has its own while loop and switch case for handling the user input.
while (continueRunning)
{
    // call for the main menu from the Extra class, passing the email of the active user or a default message if no user is logged in.  
    // I am using the null conditional operator and the null coalescing operator for this. 
    // It is a concise way to handle null values as an if statement. 
    // if we have value from active_user.Email it will be used otherwise the default message will be used.
    // Need to work even if the active_user is nill. Thats why we have activ_user?. 
    // So it could nullable
    Extra.MainMenu(active_user?.Email ?? "No user logged in");
    // int the switch case the user will enter the input for the main menu.
    // for the switch there is five cases.
    switch (Console.ReadLine() ?? "")
    {
        // The first case is for log in and log out.
        case "1":
            // here we have another bool  for keeping the login menu running.
            bool loginRunning = true;
            // and the while loop that keeps it running until the loginRunning will be false.
            while (loginRunning)
            {
                // call for the login menu from the Extra class.
                Extra.AddLogin();
                // Here is another switch case for the login menu. and the user will enter the input for the login menu.
                // There is three cases. The first one is for log in a user. 
                // The second one is for log out a user. An the third one is for going back to the main menu.
                switch (Console.ReadLine() ?? "")
                {
                    case "1":
                        Console.Write("Enter username: ");
                        string? inputUsername = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string? inputPassword = Console.ReadLine();
                        // We do a check in the users list to see if the user exists.
                        // If the user exists we set the active_user to the found user.
                        // and to handle the case that the user is not adding something we use the null coalescing operator.
                        // If the user is not found we display a message to the user also. 
                        // while are using find for the users list to find the user. 
                        // Inside the find we are using a lambda expression to check if the user exists with the TryLogin method from the User class.
                        // It will loop through the entire list until it finds a match or returns null if no match is found.
                        // It will only return true if the username and password matches in the TryLogin method.
                        // we also use the null conditional operator to check if the active_user is null or not.
                        // If the foundUser is null we display a message to the user that the login failed.
                        // And if it is not null we display a message that the login was successful.    
                        // and set the active_user to the found user.
                        User loggedInUser = users.Find(user => user.TryLogin(inputUsername ?? "", inputPassword ?? ""));
                        if (loggedInUser != null)
                        {
                            active_user = loggedInUser;
                            // ive desided to exit the login menu after a successful login.
                            loginRunning = false;
                            // if have created two methods in the Extra class for displaying success and alert messages.
                            Extra.DisplaySuccesText("Login successful.");
                        }
                        else
                        {
                            // here is one for the alert messages function. The diffrence is the color of the text.
                            Extra.DisplayAlertText("Login failed. Incorrect username or password.");
                        }
                        // There is two ways to handle a pause in the program.
                        // one is to use Console.ReadLine() and the other one is to use Thread.Sleep(milliseconds).
                        // I have choosen to use Thread.Sleep for this program.
                        // There is a reason for this. Because there is nothing special for the user to interact with.
                        Thread.Sleep(3000);
                        break;
                    case "2":
                        // For log out we do a check to see if there is an active user.
                        // if there is we set the active_user to null and display a message that the user has been logged out.
                        // if there is no active user we display a message that no user is logged in.
                        if (active_user != null)
                        {
                            // if there is an active user we log out the user by setting the active_user to null.
                            active_user = null;
                            Extra.DisplaySuccesText("Logged out successfully.");
                            Thread.Sleep(3000);
                        }
                        else
                        {
                            // if there is no active user we display a message that no user is logged in.
                            Extra.DisplayAlertText("No user is currently logged in.");
                            Thread.Sleep(3000);
                            // and i exit this loop and go up one step in the menu 
                            loginRunning = false;
                            break;
                        }
                        break;
                }
            }
            break;
        case "2":
            // in the second case for the first loop i am handling the accounts. 
            // here we have another bool variable for the while loop. 
            bool accountRunning = true;
            // The while loop will continoue until the accountRunning will be false
            while (accountRunning)
            {
                // Here i call the Accountmenu from the Class Extra. 
                Extra.Accountmenu();
                // while have another switch that the user will enter the input from the menu above.
                // there will be three cases for the switch. Only two of them are operational. 
                // Dont know if i will create a removal of account. perhaps its own account in that case. 
                // So the first case is for creating a new account. The third one is for going up a step in the menu.   
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
            // The third case for the main menu is the handling of the items. 
            // first there is a check if there is an active user.
            // if not then there will be a alert text that there is no one logged in
            if (active_user == null)
            {
                Extra.DisplayAlertText("No user is currently logged in.");
                Thread.Sleep(3000);
                break;
            }
            else
            {
                // if there is a user logged in we set a boolena variable to true. 
                bool itemRunning = true;
                // we use that for the while loop so it will continue until the user execute a stop for it. 
                while (itemRunning)
                {
                    // Here we call on the itemMenu from the Extra class 
                    Extra.itemMenu();
                    // The switch is handlign the users input
                    // There is four cases that handles 
                    // added item, showing your own items
                    // showing all other users items and the last one is going up to the main menu.
                    switch (Console.ReadLine() ?? "")
                    {
                        case "1":
                            // the first case is handling the adding a new item. 
                            // from what the construction of a new item it need the name and 
                            // the description for the new item. 
                            Console.WriteLine("Adding new item selected.");
                            // We are asking the user to enter a name they want to give the item. 
                            Console.Write("Enter item name: ");
                            string itemName = "";
                            // to check so the user is going to enter a value to the name of Item, 
                            // i am using a while loop that is checking 
                            // if the value of the string,aka the ItemName, 
                            // is null or only white space. 
                            // Default it will be true becase we set it to empthy string above.
                            while (string.IsNullOrWhiteSpace(itemName))
                            {
                                // writing on the screen.
                                Console.WriteLine("Enter item name:");
                                // user is giving a input back and save it to the value itemName
                                // If the user press enter it will be a empthy string
                                itemName = Console.ReadLine() ?? "";

                                // Here we check if the itemName is still empthy 
                                // and in that case we will print a message to the user.  
                                if (string.IsNullOrWhiteSpace(itemName))
                                {
                                    Extra.DisplayAlertText("You need to give a name to the item.");

                                }
                            }

                            // I am thinking that we dont need to do the same check for 
                            // description. We let the user choose if they want that empthy,
                            // for now. Could be a WIP.
                            Console.Write("Enter item description: ");
                            string itemDescription = Console.ReadLine() ?? "";
                            items.Add(new Item(itemName, itemDescription));
                            Extra.DisplaySuccesText("Item added successfully.");
                            active_user?.AddItem(new Item(itemName, itemDescription));
                            Thread.Sleep(3000);
                            break;
                        case "2":
                            // This case is handling the display of the user that is logged in.
                            Console.WriteLine("Your items:");
                            // calling a function from user class to show all the items for the 
                            // user that is logged in aka the user that is added to the active_user.
                            active_user.ShowItems();
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
                                            Trade trade = sentTrades[i];
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
                                        if (int.TryParse(Console.ReadLine(), out int tradeIndex) && tradeIndex > 0 && tradeIndex <= recivedTrades.Count)
                                        {
                                            Trade selectedTrade = recivedTrades[tradeIndex - 1];
                                            Console.WriteLine("1. Accept Trade");
                                            Console.WriteLine("2. Deny Trade");
                                            Console.Write("Choose an option: ");
                                            string? actionChoice = Console.ReadLine();
                                            if (actionChoice == "1")
                                            {
                                                selectedTrade.AcceptTrade();
                                                Extra.DisplaySuccesText("Trade accepted.");
                                            }
                                            else if (actionChoice == "2")
                                            {
                                                selectedTrade.DenyTrade();
                                                Extra.DisplaySuccesText("Trade denied.");
                                            }
                                            else
                                            {
                                                Extra.DisplayAlertText("Invalid action choice.");
                                            }
                                        }
                                        else
                                        {
                                            Extra.DisplayAlertText("Invalid trade selection.");
                                        }
                                        Thread.Sleep(2000);
                                    }
                                    break;
                                case "3":
                                    List<Trade> acceptedTrades = trades.Where(t => (t.Sender == active_user || t.Receiver == active_user) && t.Status == TradeStatus.Accepted).ToList();
                                    if (acceptedTrades.Count == 0)
                                    {
                                        Extra.DisplayAlertText("No accepted trade requests.");
                                        Thread.Sleep(3000);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Accepted trade requests:");
                                        for (int i = 0; i < acceptedTrades.Count; i++)
                                        {
                                            Trade trade = acceptedTrades[i];
                                            Console.WriteLine($"{i + 1}. Status: {trade.Status} | With: {(trade.Sender == active_user ? trade.Receiver.Email : trade.Sender.Email)} | You offered: {trade.ItemTraded[0].Name} | You received: {trade.ItemTraded[1].Name}");
                                        }
                                        Thread.Sleep(3000);
                                    }
                                    break;
                                case "4":
                                    List<Trade> deniedTrades = trades.Where(t => (t.Sender == active_user || t.Receiver == active_user) && t.Status == TradeStatus.Denied).ToList();
                                    if (deniedTrades.Count == 0)
                                    {
                                        Extra.DisplayAlertText("No denied trade requests.");
                                        Thread.Sleep(3000);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Denied trade requests:");
                                        for (int i = 0; i < deniedTrades.Count; i++)
                                        {
                                            Trade trade = deniedTrades[i];
                                            Console.WriteLine($"{i + 1}. Status: {trade.Status} | With: {(trade.Sender == active_user ? trade.Receiver.Email : trade.Sender.Email)} | You offered: {trade.ItemTraded[0].Name} | You wanted: {trade.ItemTraded[1].Name}");
                                        }
                                        Thread.Sleep(3000);
                                    }
                                    break;
                                case "5":
                                    tradeRunning = false;
                                    Thread.Sleep(3000);
                                    break;
                            }



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