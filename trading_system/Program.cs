// Todos for the trading system:
// A user needs to be able to register an account
// A user needs to be able to log out.
// A user needs to be able to log in.
// A user needs to be able to upload information about the item they wish to trade.
// A user needs to be able to browse a list of other users items.
// A user needs to be able to request a trade for other users items.
// A user needs to be able to browse trade requests.
// A user needs to be able to accept a trade request.
// A user needs to be able to deny a trade request.
// A user needs to be able to browse completed requests.

using TradingSystem;
List<User> users = new List<User>();

bool continueRunning = true;

while (continueRunning)
{
    Extra.MainMenu();
    switch (Console.ReadLine() ?? "")
    {
        case "1":
            // Code to create account
            Console.WriteLine("Create account selected.");
            string inpiutUsername = Console.ReadLine() ?? "";
            string inputPassword = Console.ReadLine() ?? "";
            users.Add(new user(inpiutUsername, inputPassword));
            Console.WriteLine("user created.");
            Thread.Sleep(4000);
            break;
        case "2":
            Console.WriteLine("Login account selected.");
            break;
        case "3":
            Console.WriteLine("Exiting...");
            continueRunning = false;
            break;
    }
    // Main trading system logic here
}