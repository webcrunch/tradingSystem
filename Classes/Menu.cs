namespace TradingSystem;

class Menu
{
    public static void MainMenu(string username)
    {
        string userStatus = string.IsNullOrEmpty(username) ? "No user logged in" : username;

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ╔════════════════════════════════╗");
        Console.WriteLine("  ║    --  Trading System  --      ║");
        Console.WriteLine("  ║        Choose a number         ║");
        Console.WriteLine($"  ║       User {userStatus,-20}║");
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


    public static void Trademenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
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




    public static void ShowTradeHandlingMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
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