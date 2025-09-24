// Todos for the trading system:
// A user needs to be able to register an account  ---- klart
// A user needs to be able to log out. ----- Klart
// A user needs to be able to log in. ----- Klart
// A user needs to be able to upload information about the item they wish to trade. ---- Klart


// A user needs to be able to browse a list of other users items. ---- Klart

// Refactor the need above . ---- Klart mayb
// A user needs to be able to request a trade for other users items. WIP

// A user needs to be able to browse trade requests.

// A user needs to be able to accept a trade request.
// A user needs to be able to deny a trade request.
// A user needs to be able to browse completed requests.

/// only accept/deny the user is the recepter. 

using TradingSystem;
List<User> users = new List<User>();
List<Item> items = new List<Item>();

bool continueRunning = true;
User? active_user = null;


// Creating a dump user and item for testing
users.Add(new User("test", "test")); // Default user for testing
active_user = users[0];
active_user.AddItem(new Item("Böcker", "32 stycken nalle puh böcker")); // Default item for testing
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
                            active_user?.ShowItems(items);
                            break;
                        case "3":
                            Console.WriteLine("Showing all others items:");
                            foreach (User user in users)
                            {
                                if (user == active_user) continue; // Skip the active user's items
                                user.ShowItems(items);
                            }
                            break;
                        case "4":
                            itemRunning = false;
                            break;
                    }
                }
            }
            break;
        case "7":
            Console.WriteLine("Exiting...");
            continueRunning = false;
            break;
    }
}