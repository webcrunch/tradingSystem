namespace TradingSystem;

// public Class Utils
// {
//     public static void MainMenu()
// {

// }



class Extra
{

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

    public static void MainMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔════════════════════════════════╗");
        Console.WriteLine("║    --  Trading System  --      ║");
        Console.WriteLine("║        Choose a number         ║");
        Console.WriteLine("╠════════════════════════════════╣");
        Console.WriteLine("║     1. (Create account)        ║");
        Console.WriteLine("║     2. (Login account)         ║");
        Console.WriteLine("║     3. (Logout account)        ║");
        Console.WriteLine("║     4. (handle account)        ║");
        Console.WriteLine("║     5. (Exit)                  ║");
        Console.WriteLine("╚════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ResetColor(); // Återställer textfärgen
    }

    public static void Addmenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔══════════════════════╗");
        Console.WriteLine("║  Add new Item Meny   ║");
        Console.WriteLine("╠══════════════════════╣");
        Console.WriteLine("║ 1. Add new item      ║");
        Console.WriteLine("║ 2. Add new weapon    ║");
        Console.WriteLine("║ 3. Add new armor     ║");
        Console.WriteLine("║ 4. Quit              ║");
        Console.WriteLine("╚══════════════════════╝");
        Console.ResetColor(); // Återställer textfärgen
    }
}