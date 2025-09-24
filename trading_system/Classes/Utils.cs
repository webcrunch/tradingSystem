namespace TradingSystem;

// public Class Utils
// {
//     public static void MainMenu()
// {

// }



class Extra
{


    public static void DisplaySuccesText(string text, int delay = 50)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{text}");
        Console.ResetColor(); // Återställer textfärgen        
    }
    public static void DisplayAlertText(string text, int delay = 50)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{text}");
        Console.ResetColor(); // Återställer textfärgen        
    }

    public static bool UserExisting(List<User> users)
    {
        return users.Count > 0;
    }

    public static void MainMenu(string username = "No user logged in")
    {
        string userStatus = string.IsNullOrEmpty(username) ? "No user logged in" : username;

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        // Console.WriteLine(" ╔════════════════════════════════╗");
        // Console.WriteLine(" ║    --  Trading System  --      ║");
        // Console.WriteLine(" ║        Choose a number         ║");
        // Console.WriteLine($" ║    User  {username}           ║");
        // Console.WriteLine(" ╠════════════════════════════════╣");
        // Console.WriteLine(" ║        1. (Login)              ║");
        // Console.WriteLine(" ║        2. (Account)            ║");
        // Console.WriteLine(" ║        3. (Item)               ║");
        // Console.WriteLine(" ║        4. (Trade)              ║");
        // // Console.WriteLine("║     4. (Create item)           ║");
        // // Console.WriteLine("║     5. (Show Your item)        ║");
        // // Console.WriteLine("║     6. (Show others items)     ║");
        // Console.WriteLine(" ║        7. (Exit)               ║");
        // Console.WriteLine(" ╚════════════════════════════════╝");
        // set the width of the box based on the length of the username
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
        Console.WriteLine(" ║ 3. Go up                 ║ ");
        Console.WriteLine(" ╚══════════════════════════╝ ");
        Console.ResetColor(); // Återställer textfärgen
    }


    public static void itemMenu(string text)
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


    public static void Displayusers(List<User> users, User active_user)
    {
        Console.WriteLine("List of users:");
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i] != active_user)
            {
                Console.WriteLine($"{i + 1}. {users[i].Email}");
            }

        }
    }

    public static void AddLogin()
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