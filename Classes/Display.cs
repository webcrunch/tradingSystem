namespace TradingSystem;


class Display
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

    public static void DisplayUsers(List<User> users, User active_user)
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
}