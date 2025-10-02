namespace TradingSystem;

/// <summary>
/// Provides helper methods for displaying styled text and user lists
/// in the Trading System console application.
/// I am working with tre diffrent displays. Two displays for good and bad things that we display to the user
/// and then a list loop of user that we display on the screen.
/// </summary>
class Display
{
    /// <summary>
    /// Displays a success message in green text.
    /// </summary>
    /// <param name="text">The message to display.</param>
    /// <param name="delay">Optional delay parameter (currently unused).</param>
    public static void DisplaySuccesText(string text, int delay = 50)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{text}");
        Console.ResetColor(); // Clear the color        
    }

    /// <summary>
    /// Displays an alert message in red text.
    /// </summary>
    /// <param name="text">The message to display.</param>
    /// <param name="delay">Optional delay parameter (currently unused).</param>
    public static void DisplayAlertText(string text, int delay = 50)
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{text}");
        Console.ResetColor(); // Clear the color        
    }
    /// <summary>
    /// Displays a list of users, excluding the currently active user.
    /// Shows each user's username and the number of items available for trade.
    /// </summary>
    /// <param name="users">The list of all users.</param>
    /// <param name="active_user">The currently active user to exclude from the list.</param>
    public static void DisplayUsers(List<User> users, User active_user)
    {
        Console.WriteLine("List of users:");
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i] != active_user)
            {
                Console.WriteLine($"{i + 1}. {users[i].Username}. ({users[i].getAmoutOfItemsForUser()}) items for trade ");
            }

        }
    }
}