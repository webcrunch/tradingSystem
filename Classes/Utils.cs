namespace TradingSystem;


class Extra
{

    public static bool UserExisting(List<User> users)
    {
        return users.Count > 0;
    }


    // creating a function that handles all the waiting for the user to go further
    public static void WaitForInput()
    {
        Console.WriteLine("\n Press a key to continue...");
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
                Display.DisplayAlertText("The input could not be empthy. Try again");
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
                Display.DisplayAlertText("Not accepteble input. User only numbers.");
                WaitForInput();
            }
        }
    }



}