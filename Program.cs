// Todos for the trading system:
// TODO: A user needs to be able to register an account  ---- finished
// TODO: A user needs to be able to log out. ----- finished
// TODO: A user needs to be able to log in. ----- finished
// TODO: A user needs to be able to upload information about the item 
// TODO: they wish to trade. ---- finished

// TODO: A user needs to be able to browse a list of other users items. ---- finished

// TODO: Refactor the need above . ---- finished 
// TODO: A user needs to be able to request a trade for other users items. ---- finished
// TODO: A user needs to be able to see a list of their sent trade requests. ---- finished
// TODO: A user needs to be able to cancel a sent trade request. ---- finished

// TODO: A user needs to be able to browse trade requests. --- finished

// TODO: A user needs to be able to accept a trade request. --- finished
// TODO: A user needs to be able to deny a trade request. --- finished

// TODO: A user needs to be able to browse completed requests. --- finished

// TODO: only accept/deny the user is the recepter. ---- finished
// TODO: only cancel the user if the sender. ---- finished
// TODO: save to file json ---- finished
// TODO: Read from json file and init data ---- finished

// I am usign the TradingSystem namespace.
using TradingSystem;
// There are two lists that carries the data from the users. 
// when we start the program the lists are populating by the value of user, items and trade txt files.
List<User> users = FileHandler.LoadUsersFromCsv();
List<Trade> trades = new List<Trade>();
// Ladda data vid start
// List<User> users = FileHandler.LoadFromJson<User>(FileHandler.SaveToJsonUser);
// List<Trade> trades = FileHandler.LoadFromJson<Trade>(FileHandler.TradeFileName);


// This bool is for controlling the main loop of the program.
bool continueRunning = true;
// This is for keeping track of the currently logged-in user. 
// default value is null, meaning no user is logged in.
User? active_user = null;

// _______ dummy data for testing purposes _________
// Creating a dump user and item for testing
// creating three users and two items for each user.
// This is just for testing purposes. and to be able to see how the program works.
// users.Add(new User("testUser", "test", "test")); // User1 for testing
// users.Add(new User("albert", "beteman", "test")); // User2 for testing
// users.Add(new User("jarl", "jarleman", "test")); // User3 user for testing
// users.Add(new User("Cat_AYBABTU", "cat@z88.net", "test")); // User3 user for testing
// users.Add(new User("TheNegotiator", "zero_wing@trade.com", "test")); // User3 user for testing
// users.Add(new User("LoneWanderer", "vault101@trade.com", "test")); // User3 user for testing
// users.Add(new User("AYBABTU@trade.com", "1991", "test"));
// Log in and create some items for the first user
// active_user = users[0]; // Log in the test user
// active_user.AddItem(new Item("Böcker", "32 stycken nalle puh böcker")); // Items for testing
// active_user.AddItem(new Item("handskar", "2 par elefanthanskar")); // Items for testing
// active_user = null; // Log out the test user
// // Creating dummy data and log in for the second user
// active_user = users[1]; // Log in the test user
// active_user.AddItem(new Item("Abombs", "100 stora atombomber")); // Items for testing
// active_user.AddItem(new Item("skor", "2 par elefantskor")); // Items for testing
// active_user = null; // Log out the test user
// // Creating dummy data and log in for the third user
// active_user = users[2]; // Log in the test user
// active_user.AddItem(new Item("Bilar", "32 stycken leksaksbilar")); // Items for testing
// active_user.AddItem(new Item("dator", "en macbook pro 2020")); // Items for testing
// active_user = null; // Log out the test user

// active_user = users[3]; // Log in the test user
// active_user.AddItem(new Item("Zero Wing Module", "Kärnmodulen från Zero Wing - kapseln.Kan vara viktigt.")); // Items for testing
// active_user.AddItem(new Item("A Big Red Button", "You Set Up Us The Bomb")); // Items for testing, Handling this trade item specila

// active_user = null; // Log out the test user

// active_user = users[4]; // Log in the test user
// active_user.AddItem(new Item("All Base Keycard", "Giver dig tillgång till alla dörrar.Kräver dock att alla dina baser tillhör oss")); // Items for testing
// active_user.AddItem(new Item("Main Screen Blueprint", "Ritningar för att slå på huvudskärmen. Försiktighet rekommenderas")); // Items for testing
// active_user.AddItem(new Item("Make Your Time Watch", "Ett armbandsur ställt på 'NU'. Kan inte justeras")); // Items for testing
// active_user.AddItem(new Item("Someone Else's Ship", "Ett rymdskepp som ingen minns vems det är.Ett bra bytesobjekt")); // Items for testing
// active_user = null; // Log out the test user

// _______ end of dummy data for testing purposes _________

// i have decided to create a class named Menu for handling the menu system.
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
    // I have this check here if the user is logged in or not. if user is not logged in we send the string otherwise we send the username from the object
    Menu.MainMenu(active_user?.Username ?? "No user logged in");
    // int the switch case the user will enter the input for the main menu.
    // for the switch there is five cases.
    switch (Extra.GetIntegerInput(""))
    {
        // The first case is for log in and log out. 
        // I am doing this because i want to break out functionality for the user 
        // into multiple parts. 
        // I think this is easier both when i am working with it and 
        // when the user is using the program.
        case 1:
            // Need to check if there is no users at all 
            if (Extra.UserExisting(users))
            {
                // here we have another bool  for keeping the login menu running.
                bool loginRunning = true;
                // and the while loop that keeps it running until the loginRunning will be false.
                while (loginRunning)
                {
                    // call for the login menu from the Extra class.
                    Menu.AddLoginMenu();
                    // Here is another switch case for the login menu. and the user will enter the input for the login menu.
                    // There is three cases. The first one is for log in a user. 
                    // The second one is for log out a user. An the third one is for going back to the main menu.

                    switch (Extra.GetIntegerInput(""))
                    {
                        case 1:
                            // Check if the user is already logged in. 
                            // Then there will be no access here until loged out
                            if (active_user != null)
                            {
                                Display.DisplayAlertText("You are already logged in");
                            }
                            else
                            {
                                string inputUsername = Extra.GetRequiredInput("Enter username: ");
                                string inputPassword = Extra.GetRequiredInput("Enter password: ");
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
                                // I am using a find function for the users array. It works like i am looping through all the array of users
                                // and map current user with the rules. It is checking first if the input from the user is not null.  
                                // If that is true the rule continues and call the function TryLogin to check if the input from the user will return a true or false.
                                // If both rules returns true then it return the user from the users array that it finds.  
                                User? loggedInUser = users.Find(user =>
                                    (inputUsername != null && inputPassword != null) &&
                                    user.TryLogin(inputUsername, inputPassword) == true
                                );
                                // If we find a users we will set that user to active user. And stop the current while loop. 
                                // That makes it go up on levet. And Display a message that login succeded. 
                                if (loggedInUser != null)
                                {
                                    active_user = loggedInUser;
                                    // ive desided to exit the login menu after a successful login.
                                    loginRunning = false;
                                    // if have created two methods in the Extra class for displaying success and alert messages.
                                    Display.DisplaySuccesText("Login successful.");
                                }
                                // If we dont find any user or input is not any 
                                else
                                {
                                    // here is one for the alert messages function. The diffrence is the color of the text.
                                    Display.DisplayAlertText("Login failed. Incorrect username or password.");
                                }
                                // Using a externa function to "pause" and wait for a key press from the user to continue  
                                Extra.WaitForInput();
                                break;
                            }
                            break;
                        case 2:
                            // For log out we do a check to see if there is an active user.
                            // if there is we set the active_user to null and display a message that the user has been logged out.
                            // if there is no active user we display a message that no user is logged in.
                            if (active_user != null)
                            {
                                // if there is an active user we log out the user by setting the active_user to null.
                                active_user = null;
                                Display.DisplaySuccesText("Logged out successfully.");
                                Extra.WaitForInput();
                            }
                            else
                            {
                                // if there is no active user we display a message that no user is logged in.
                                Display.DisplayAlertText("No user is currently logged in.");
                                Extra.WaitForInput();
                                // and i exit this loop and go up one step in the menu 
                                loginRunning = false;
                                break;
                            }
                            break;
                        case 3:
                            loginRunning = false;
                            break;
                    }
                }
            }
            else
            {
                Display.DisplayAlertText("There is no account accible for the moment. \n Create new account to login");
                Extra.WaitForInput();
            }
            break;
        case 2:
            // in the second case for the first loop i am handling the accounts. 
            // here we have another bool variable for the while loop. 
            bool accountRunning = true;
            // The while loop will continoue until the accountRunning will be false
            while (accountRunning)
            {
                // Here i call the Accountmenu from the Class Extra. 
                Menu.Accountmenu();
                // while have another switch that the user will enter the input from the menu above.
                // there will be three cases for the switch. Only two of them are operational. 
                // Dont know if i will create a removal of account. perhaps its own account in that case. 
                // So the first case is for creating a new account. The third one is for going up a step in the menu.   
                switch (Extra.GetIntegerInput("Choose an option: "))
                {
                    case 1:
                        Console.WriteLine("Create account selected.");
                        string CreateInputEmail = Extra.GetRequiredInput("Enter email for the account: ");
                        string CreateInputUsername = Extra.GetRequiredInput("Enter username for the account: ");
                        string CreateInputPassword = Extra.GetRequiredInput("Enter password for the account: ");
                        // string[] userExist = users.Find(us =>  );
                        users.Add(new User(CreateInputUsername, CreateInputEmail, CreateInputPassword));
                        Display.DisplaySuccesText("Account created successfully.");
                        Extra.WaitForInput();
                        break;
                    case 3:
                        accountRunning = false;
                        break;
                }
            }
            break;
        case 3:
            // The third case for the main menu is the handling of the items. 
            // first there is a check if there is an active user.
            // if not then there will be a alert text that there is no one logged in
            if (active_user == null)
            {
                Display.DisplayAlertText("No user is currently logged in.");
                Extra.WaitForInput();
                break;
            }
            else
            {
                // if there is a user logged in we set a boolena variable to true. 
                bool itemRunning = true;
                // we use that for the while loop so it will continue until the user execute a stop for it. 
                while (itemRunning)
                {
                    // Here we call on the itemMenu from the Menu class 
                    Menu.itemMenu();
                    // The switch is handlign the users input
                    // There is four cases that handles 
                    // added item, showing your own items
                    // showing all other users items and the last one is going up to the main menu.
                    // the getIntegerInput handle verification of numbers and will only continue if user
                    // inputs a real number. Negative works also. :/
                    switch (Extra.GetIntegerInput(""))
                    {
                        case 1:
                            // the first case is handling the adding a new item. 
                            // from what the construction of a new item it need the name and 
                            // the description for the new item. 
                            Console.WriteLine("Adding new item selected.");
                            // We are asking the user to enter a name they want to give the item.
                            // The function handle the check so the user cant set the name empthy 
                            string itemName = Extra.GetRequiredInput("Enter item name: ");

                            // I am thinking that we dont need to do the same check for 
                            // description. We let the user choose if they want that empthy,
                            // for now. Could be a WIP.
                            Console.Write("Enter item description: ");
                            string itemDescription = Console.ReadLine() ?? "";
                            // // create a list for one item 
                            // List<Item> items = new List<Item>();
                            // items.Add(new Item(itemName, itemDescription));
                            Display.DisplaySuccesText("Item added successfully.");
                            active_user?.AddItem(new Item(itemName, itemDescription, "None"));
                            Extra.WaitForInput();
                            break;
                        case 2:
                            // This case is handling the display of the user that is logged in.
                            Console.WriteLine("Your items:");
                            // calling a function from user class to show all the items for the 
                            // user that is logged in aka the user that is added to the active_user.
                            active_user?.ShowItems();
                            break;
                        case 3:
                            // The third case is handling the display of all the items that all the other users has created 
                            Console.WriteLine("Showing all others items:");
                            // to find all the users we are looping through the users list with a foreach loop
                            foreach (User user in users)
                            {
                                // and when we get to the user that is logged in we skip that user and just continue the loop
                                if (user == active_user) continue; // Skip the active user's items
                                                                   // and then we are calling the showItem function for that user and display its items. 
                                user.ShowItems();
                            }
                            break;
                        case 4:
                            itemRunning = false;
                            break;
                    }
                }
            }
            break;
        case 4:

            if (active_user == null)
            {
                // If there is no user logged in there will be a message 
                // and then the user needs to press a key to move further. 
                Display.DisplayAlertText("No user is currently logged in.");
                Extra.WaitForInput();

                break;
            }
            else
            {
                bool tradeRunning = true;
                while (tradeRunning)
                {
                    Menu.Trademenu();
                    switch (Extra.GetIntegerInput("Choose an option: "))
                    {
                        case 1:
                            Console.WriteLine("Request trade selected");
                            // we are calling the function that display all the users in the application exept for the 
                            // user that is logged in.
                            // We are sending all the users and to verifie we are not adding the 
                            // active user to the list we add that too.
                            Display.DisplayUsers(users, active_user);

                            // getting the index for the user that we want to interact with. 
                            // There is a function that handles all the check of input from the user.
                            // It will be less repeteive. DRY (Dont repeat yourself) principle.
                            // So when the validation is tru the input will be saved to the userIndex variable. 
                            int userIndex = Extra.GetIntegerInput("Select a user to trade with (enter a number)");

                            //  Here we check if the user has added the index of itself. 
                            // First we check if the userIndex is bigger than zero. So no negative numbers.
                            // Or is inside the amount of users in the list.  
                            if (userIndex > 0 && userIndex <= users.Count)
                            {
                                // here we save the reciving to a variable because we are going to work with it later.
                                // because we are displaying numbers starting with 1 we need to subtract by 1 to get the right index.
                                User receiver = users[userIndex - 1];
                                // check so that the reciving part is not the same as the logged in part.
                                if (receiver != active_user)
                                {
                                    // Choose the item that the user wants to trade
                                    Console.WriteLine($"Selected user: {receiver.Username}");
                                    Console.WriteLine("Select a item to trade from your items");
                                    active_user.ShowItems(false);
                                    Console.WriteLine(active_user.ItemForTrade());
                                    // string itemToTradeName = Extra.GetRequiredInput("Enter the name of the item you want to trade:");
                                    // let the user choose a name of item. After that is sent to the function that search if the item is in the users list. 
                                    // It could be returned null if there is no found. Thats why we set Item as nullable.
                                    if (active_user.ItemForTrade() != true)
                                    {
                                        Display.DisplayAlertText("No more item to from you. Add more items");
                                        Extra.WaitForInput();
                                        break;
                                    }
                                    if (receiver.ItemForTrade() != true)
                                    {
                                        Display.DisplayAlertText("No more item to from the recipiant. You cant trade with that person");
                                        Extra.WaitForInput();
                                        break;
                                    }
                                    Item? itemToTrade = active_user.FindItem(Extra.GetRequiredInput("Enter the name of the item you want to trade:"));

                                    if (itemToTrade == null)
                                    {
                                        Display.DisplayAlertText("Item not found in your items list.");
                                        Extra.WaitForInput();
                                        break;
                                    }
                                    Console.WriteLine("\n Select a item to recive from the other\\´s users items:");
                                    receiver.ShowItems(false);

                                    Item? itemToRecive = receiver.FindItem(Extra.GetRequiredInput("Enter the name of the item you want to receive: "));
                                    if (itemToRecive == null)
                                    {
                                        Display.DisplayAlertText("Item not found in their items  list.");
                                        Extra.WaitForInput();
                                        break;
                                    }
                                    itemToTrade.TradingLimbo = Item.TradingStatus.Trading;
                                    itemToRecive.TradingLimbo = Item.TradingStatus.Trading;
                                    Item[] newtradedItems = new Item[] { itemToTrade, itemToRecive };

                                    trades.Add(new Trade(active_user, receiver, newtradedItems));
                                    string senderMessage = $"You have sent a trade request to {receiver.Email} for item {itemToRecive.Name}.";
                                    string receiverMessage = $"{active_user.Username} has requested to trade their item {itemToTrade.Name} for your item {itemToRecive.Name}.";

                                    active_user.message.Add(senderMessage);
                                    receiver.message.Add(receiverMessage);

                                    Display.DisplaySuccesText("Trade request sent succefully");
                                }
                                else
                                {
                                    Display.DisplayAlertText("You cannot trade with yourself.");

                                }
                            }
                            else
                            {
                                Display.DisplayAlertText("Invalid user selection.");
                            }
                            Extra.WaitForInput();
                            break;
                        case 2:
                            active_user.displayMessage();
                            Extra.WaitForInput();

                            break;
                        case 3:
                            Menu.ShowTradeHandlingMenu();
                            switch (Extra.GetIntegerInput("Choose an option: "))
                            {
                                case 1:
                                    List<Trade> sentTrades = trades.Where(t => t.Sender == active_user && t.Status != TradeStatus.Canceled).ToList();
                                    if (sentTrades.Count == 0)
                                    {
                                        Display.DisplayAlertText("No sent trade requests.");
                                        Extra.WaitForInput();

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
                                        Extra.WaitForInput();

                                    }
                                    string cancelChoice = Extra.GetRequiredInput("Do you want to cancel a sent trade request? (y/n)");
                                    if (cancelChoice.ToLower() == "y")
                                    {

                                        // handle integer validation from external function and print message to user if anyting wrong. 
                                        int cancelIndex = Extra.GetIntegerInput("Enter the number of the trade to cancel: ");

                                        if (cancelIndex > 0 && cancelIndex <= sentTrades.Count)
                                        {
                                            Trade tradeToCancel = sentTrades[cancelIndex - 1];
                                            if (tradeToCancel.Status == TradeStatus.Pending)
                                            {
                                                tradeToCancel.Status = TradeStatus.Canceled;
                                                tradeToCancel.ItemTraded[0].TradingLimbo = Item.TradingStatus.None;
                                                tradeToCancel.ItemTraded[1].TradingLimbo = Item.TradingStatus.None;
                                                string senderMessage = $"You have canceled the trade request to {tradeToCancel.Receiver.Email}.";
                                                string receiverMessage = $"{active_user.Email} has canceled the trade request.";
                                                active_user.message.Add(senderMessage);
                                                tradeToCancel.Receiver.message.Add(receiverMessage);
                                                Display.DisplaySuccesText("Trade request canceled.");
                                            }
                                            else
                                            {
                                                Display.DisplayAlertText("Only pending trades can be canceled.");
                                            }
                                        }
                                        else
                                        {
                                            Display.DisplayAlertText("Invalid trade selection.");
                                        }
                                        Extra.WaitForInput();

                                    }
                                    break;
                                case 2:

                                    List<Trade> recivedTrades = trades.Where(t => t.Receiver.Email == active_user.Email && t.Status == TradeStatus.Pending).ToList();

                                    if (recivedTrades.Count == 0)
                                    {
                                        Display.DisplayAlertText("No pending trade requests.");
                                        Extra.WaitForInput();

                                    }
                                    else
                                    {
                                        Console.WriteLine("Pending trade requests:");
                                        for (int i = 0; i < recivedTrades.Count; i++)
                                        {
                                            Trade trade = recivedTrades[i];

                                            Console.WriteLine($"{i + 1}. Status: {trade.Status} | From: {trade.Sender.Email} | They offer: {trade.ItemTraded[0].Name} | They want: {trade.ItemTraded[1].Name}");
                                        }
                                        int tradeIndex = Extra.GetIntegerInput("Select a trade to handle (enter number):");
                                        if (tradeIndex > 0 && tradeIndex <= recivedTrades.Count)
                                        {
                                            Trade selectedTrade = recivedTrades[tradeIndex - 1];
                                            Menu.TradeOptionsMenu();
                                            switch (Extra.GetIntegerInput("Choose an option:"))
                                            {
                                                case 1:
                                                    selectedTrade.AcceptTrade();
                                                    Display.DisplaySuccesText("Trade accepted.");
                                                    break;

                                                case 2:
                                                    selectedTrade.DenyTrade();
                                                    Display.DisplaySuccesText("Trade denied.");
                                                    break;
                                                case 3:
                                                    break;
                                                default:
                                                    Display.DisplayAlertText("Invalid action choice.");
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Display.DisplayAlertText("Invalid trade selection.");
                                        }
                                        Extra.WaitForInput();
                                    }
                                    break;
                                case 3:
                                    List<Trade> acceptedTrades = trades.Where(t => (t.Sender == active_user || t.Receiver == active_user) && t.Status == TradeStatus.Accepted).ToList();
                                    if (acceptedTrades.Count == 0)
                                    {
                                        Display.DisplayAlertText("No accepted trade requests.");
                                        Extra.WaitForInput();
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
                                        Extra.WaitForInput();
                                    }
                                    break;
                                case 4:
                                    List<Trade> deniedTrades = trades.Where(t => (t.Sender == active_user || t.Receiver == active_user) && t.Status == TradeStatus.Denied).ToList();
                                    if (deniedTrades.Count == 0)
                                    {
                                        Display.DisplayAlertText("No denied trade requests.");
                                        Extra.WaitForInput();
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
                                        Extra.WaitForInput();
                                    }
                                    break;
                                case 5:
                                    tradeRunning = false;
                                    Extra.WaitForInput();
                                    break;
                            }
                            break;
                        case 4:
                            tradeRunning = false;
                            Extra.WaitForInput();
                            break;
                    }
                }
                break;
            }
        case 7:
            Console.WriteLine("Exiting...");
            FileHandler.SaveUsersToCsv(users);
            FileHandler.SaveTradesToCsv(trades);
            continueRunning = false;
            break;
    }
}