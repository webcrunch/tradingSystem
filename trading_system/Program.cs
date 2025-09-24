// Todos for the trading system:
// A user needs to be able to register an account  ---- klart
// A user needs to be able to log out. ----- Klart
// A user needs to be able to log in. ----- Klart
// A user needs to be able to upload information about the item they wish to trade.
// A user needs to be able to browse a list of other users items.
// A user needs to be able to request a trade for other users items.
// A user needs to be able to browse trade requests.
// A user needs to be able to accept a trade request.
// A user needs to be able to deny a trade request.
// A user needs to be able to browse completed requests.

using TradingSystem;
List<User> users = new List<User>();
List<Item> items = new List<Item>();

bool continueRunning = true;
User? active_user = null;

while (continueRunning)
{
    Extra.MainMenu();
    switch (Console.ReadLine() ?? "")
    {
        case "1":
            // Code to create account
            Console.WriteLine("Create account selected.");
            Console.Write("Enter username for the account: ");
            string CreateInputUsername = Console.ReadLine() ?? "";
            Console.Write("Enter password for the account: ");
            string CreateInputPassword = Console.ReadLine() ?? "";
            users.Add(new User(CreateInputUsername, CreateInputPassword));
            Console.WriteLine("user created.");
            Thread.Sleep(3000);
            break;
        case "2":
            if (Extra.UserExisting(users) && active_user == null)
            {
                Console.WriteLine("Login account selected.");
                Console.Write("Enter username: ");
                string inputUsername = Console.ReadLine() ?? "";
                Console.Write("Enter password: ");
                string inputPassword = Console.ReadLine() ?? "";

                foreach (var user in users)
                {
                    if (user.TryLogin(inputUsername, inputPassword))
                    {
                        active_user = user;
                        break;
                    }
                }
                if (active_user != null)
                {
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Extra.DisplayAlertText("Login failed. Incorrect username or password.");
                    // Console.WriteLine("Login failed. Incorrect username or password.");
                }
                Thread.Sleep(3000);
            }
            else
            {
                if (active_user == null)
                {
                    Extra.DisplayAlertText("No users available. Please create an account first.");
                    // Console.WriteLine("No users available. Please create an account first.");
                    Thread.Sleep(3000);
                    break;
                }
                else
                {
                    Extra.DisplayAlertText("You are already logged in.");
                    Thread.Sleep(3000);
                    break;
                }
            }
            break;
        case "3":
            if (active_user != null)
            {
                active_user = null;
                Console.WriteLine("Logged out successfully.");
                Thread.Sleep(3000);
                break;
            }
            else
            {
                Extra.DisplayAlertText("No user is currently logged in.");
                // Console.WriteLine("No user is currently logged in.");
                Thread.Sleep(3000);
                break;
            }

        case "4":
            if (active_user == null && !Extra.UserExisting(users))
            {
                Extra.DisplayAlertText("You need to be logged in to add an item.");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Adding new item selected.");
                Console.Write("Enter item name: ");
                string itemName = Console.ReadLine() ?? "";
                Console.Write("Enter item description: ");
                string itemDescription = Console.ReadLine() ?? "";
                items.Add(new Item(itemName, itemDescription));
                Console.WriteLine("Item added successfully.");
                active_user?.AddItem(new Item(itemName, itemDescription));
                Thread.Sleep(3000);
            }

            break;
        case "5":
            if (active_user == null && !Extra.UserExisting(users))
            {
                Extra.DisplayAlertText("You need to be logged in to view your items.");
                Thread.Sleep(3000);
                break;
            }
            else
            {
                Console.WriteLine("Your items:");
                active_user?.ShowItems(items);
            }
            break;
        case "6":
            Console.WriteLine("Exiting...");
            continueRunning = false;
            break;
    }
}