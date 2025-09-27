namespace TradingSystem;


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


    public static void ShowMenyTradeHandling()
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


    // creating a function that handles all the waiting for the user to go further
    public static void WaitForInput()
    {
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        // using the Readkey instead of Readline 
        // because we only need to get one buttonpress
        // I am adding the true in the ReadKey to not display the key
        // the user is sending in for this event.  
        Console.ReadKey(true);
    }



    public static string GetRequiredInput(string promptMessage)
    {
        string? input = null;

        // Fortsätt fråga i en loop tills inmatningen är ett giltigt värde
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.Write(promptMessage);

            // Läs inmatning. Använd ?? "" för att garantera att 'input' aldrig är null.
            input = Console.ReadLine() ?? "";

            // Om inmatningen fortfarande är tom, visa ett felmeddelande.
            if (string.IsNullOrWhiteSpace(input))
            {
                // Använder din befintliga felmeddelande-funktion
                DisplayAlertText("The input could not be empthy. Try again");
                Thread.Sleep(1000); // Kort paus innan frågan ställs igen
            }
        }

        // Returnera det validerade (icke-tomma) värdet
        return input;
    }

    public static int GetIntegerInput(string promptMessage)
    {
        while (true) // The loop is looping infinitly until the number is valid
        {
            Console.Write(promptMessage);
            string? input = Console.ReadLine();

            // Använder int.TryParse för att försöka konvertera till heltal
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                DisplayAlertText("Not accepteble input. User only numbers.");
                WaitForInput();
            }
        }
    }



}