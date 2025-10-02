namespace TradingSystem;

/// <summary>
/// Provides static methods for displaying different console menus
/// in the Trading System application. 
/// My ide was to break out functions that is using multiple times in the Program.cs
/// Working with DRY mentality.
/// We could have a more dynamical menu. And build it from inputs through parameters but it will take
/// to much time for this small project
/// I have tried to split the menu into multiple types. For exampel login, trade and item etc. 
/// </summary>
class Menu
{
    /// <summary>
    /// Displays the main menu of the trading system.
    /// Shows the current user if logged in, otherwise "No user logged in".
    /// </summary>
    /// <param name="username">The username of the currently logged-in user, or empty if none.</param>
    public static void MainMenu(string username)
    {
        // string[] mainMenuContent = new string[]{"Login", "Account", "Item", "Trade", "Exit"};
        string userStatus = string.IsNullOrEmpty(username) ? "No user logged in" : username;

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ╔════════════════════════════════╗");
        Console.WriteLine("  ║    -- Trading System  --       ║");
        Console.WriteLine("  ║       (Choose a number)        ║");
        Console.WriteLine($"  ║      User: {userStatus,-20}║");
        Console.WriteLine("  ╠════════════════════════════════╣");
        Console.WriteLine("  ║        1. (Login)              ║");
        Console.WriteLine("  ║        2. (Account)            ║");
        Console.WriteLine("  ║        3. (Item)               ║");
        Console.WriteLine("  ║        4. (Trade)              ║");
        Console.WriteLine("  ║        7. (Exit)               ║");
        Console.WriteLine("  ╚════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ResetColor(); // Återställer textfärgen
    }

    /// <summary>
    /// Displays the account management menu.
    /// Options include adding or deleting accounts.
    /// </summary>
    public static void Accountmenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ╔══════════════════════════╗ ");
        Console.WriteLine(" ║     Account Menu         ║ ");
        Console.WriteLine(" ╠══════════════════════════╣ ");
        Console.WriteLine(" ║ 1. Add new account       ║ ");
        Console.WriteLine(" ║ 2. maybe delete account  ║ ");
        Console.WriteLine(" ║ 3. Go up                 ║ ");
        Console.WriteLine(" ╚══════════════════════════╝ ");
        Console.ResetColor(); // Återställer textfärgen
    }

    /// <summary>
    /// Displays the trade menu.
    /// Options include starting trades, viewing messages, or handling trades.
    /// </summary>
    public static void Trademenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" ╔══════════════════════════╗ ");
        Console.WriteLine(" ║     Trade Menu           ║ ");
        Console.WriteLine(" ╠══════════════════════════╣ ");
        Console.WriteLine(" ║ 1. Trade                 ║ ");
        Console.WriteLine(" ║ 2. message of trades     ║ ");
        Console.WriteLine(" ║ 3. handle trades         ║ ");
        Console.WriteLine(" ║ 4. Go up                 ║ ");
        Console.WriteLine(" ╚══════════════════════════╝ ");
        Console.ResetColor(); // Återställer textfärgen
    }

    /// <summary>
    /// Displays the item menu.
    /// Options include adding, showing own items, or showing others' items.
    /// </summary>
    public static void itemMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ╔════════════════════════╗");
        Console.WriteLine(" ║     Item Menu          ║");
        Console.WriteLine(" ╠════════════════════════╣");
        Console.WriteLine(" ║ 1. Add new Item        ║");
        Console.WriteLine(" ║ 2. show your Item      ║");
        Console.WriteLine(" ║ 3. show others Item    ║");
        Console.WriteLine(" ║ 4. Go up               ║");
        Console.WriteLine(" ╚════════════════════════╝");
        Console.ResetColor(); // Återställer textfärgen
    }



    /// <summary>
    /// Displays the trade handling menu.
    /// Options include viewing sent, received, accepted, or denied requests.
    /// </summary>
    public static void ShowTradeHandlingMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" ╔═════════════════════════╗ ");
        Console.WriteLine(" ║       Trade Menu        ║ ");
        Console.WriteLine(" ╠═════════════════════════╣ ");
        Console.WriteLine(" ║ 1. All Sent request     ║ ");
        Console.WriteLine(" ║ 2. All Recieved request ║ ");
        Console.WriteLine(" ║ 3. All Accepted request ║ ");
        Console.WriteLine(" ║ 4. All Denied request   ║ ");
        Console.WriteLine(" ║ 5. Go up                ║ ");
        Console.WriteLine(" ╚═════════════════════════╝ ");
        Console.ResetColor(); // Återställer textfärgen
    }

    /// <summary>
    /// Displays the trade options menu.
    /// Options include accepting, denying, or ignoring a trade.
    /// </summary>
    public static void TradeOptionsMenu()
    {

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ╔═════════════════════════╗ ");
        Console.WriteLine(" ║  --- Trade Options ---  ║ ");
        Console.WriteLine(" ╠═════════════════════════╣ ");
        Console.WriteLine(" ║ 1. Accept Trade         ║ ");
        Console.WriteLine(" ║ 2. Deny Trade           ║ ");
        Console.WriteLine(" ║ 3. Do nothing           ║ ");
        Console.WriteLine(" ╚═════════════════════════╝ ");
        Console.ResetColor(); // Återställer textfärgen
        Console.WriteLine("\n");
    }

    /// <summary>
    /// Displays the login/logout menu.
    /// Options include logging in, logging out, or going back.
    /// </summary>
    public static void AddLoginMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" ╔════════════════════════╗ ");
        Console.WriteLine(" ║  Login/logout Menu     ║ ");
        Console.WriteLine(" ╠════════════════════════╣ ");
        Console.WriteLine(" ║     1. Login           ║ ");
        Console.WriteLine(" ║     2. Logout          ║ ");
        Console.WriteLine(" ║     3. Go up           ║ ");
        Console.WriteLine(" ╚════════════════════════╝ ");
        Console.ResetColor(); // Återställer textfärgen
    }
}