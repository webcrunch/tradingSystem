namespace TradingSystem;

// public Class Utils
// {
//     public static void MainMenu()
// {

// }


class Extra
{

    public static void MainMenu()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔════════════════════════════════╗");
        Console.WriteLine("║        Trading System          ║");
        Console.WriteLine("╠════════════════════════════════╣");
        Console.WriteLine("║     1. (create account)        ║");
        Console.WriteLine("║     2. (Login account)         ║");
        Console.WriteLine("║     3. (Exit)                  ║");
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
    public static void DisplayType()
    {

    }
}