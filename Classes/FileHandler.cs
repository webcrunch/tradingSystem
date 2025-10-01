namespace TradingSystem;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class FileHandler
{

    public const string UserCsvFileName = "users_export.csv";
    public const string TradeCsvFileName = "trades_export.csv";
    public const string ItemsCsvFileName = "items_export.csv";
    public const string MessageCsvFileName = "message_export.csv";

    public static void SaveUsersToCsv(List<User> users)
    {
        // 1. Lista för Users (Users skrivs över vid varje körning)
        List<string> PrintToUsers = new List<string>() { "Username,Email,Password" };
        // 2. Lista för Items (Aggregerar ALLA items från ALLA users)
        // Denna lista är tom vid start av denna funktion, vilket förhindrar dubbletter.
        List<string> PrintToItems = new List<string>() { "Owner_Username,ItemName,Description,tradingLimbo" };
        List<string> PrintToMessage = new List<string>() { "messageOwner,message" };

        foreach (User user in users)
        {
            string userHandlingText = $"{user.Username},{user.Email},{user.GetpassWord()}";
            PrintToUsers.Add(userHandlingText);

            // We are agregrating the items lines for the user thats in the loop at the time.
            foreach (Item item in user.Items)
            {
                // Inkludera ägarens Username för att veta vem som äger föremålet
                string itemHandlingText = $"{user.Username},{item.Name},{item.Description}, {item.TradingLimbo}";
                PrintToItems.Add(itemHandlingText);
            }

            foreach (string message in user.message)
            {
                // Inkludera ägarens Username för att veta vem som äger föremålet
                string itemHandlingText = $"{user.Username},{message}";
                PrintToMessage.Add(itemHandlingText);
            }
        }

        // --- SAVE USERS ---
        try
        {
            // File.WriteAllLines garanterar overwrite, vilket förhindrar dubbletter mellan sessions
            File.WriteAllLines(UserCsvFileName, PrintToUsers, Encoding.UTF8);
            // Console.WriteLine($"Användardata exporterad till {UserCsvFileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: sometinh happend when we exported the users to CVS: {ex.Message}");
        }

        // --- SAVE THE ITEMS ---
        // Call an dedicated function to write over the file with current data
        SaveAllItemsToCsv(PrintToItems);
        SaveAllMessagesToCsv(PrintToMessage);
    }

    public static void SaveAllMessagesToCsv(List<string> MessageLine)
    {
        try
        {
            foreach (string bla in MessageLine)
            {
                Console.WriteLine(bla);
            }
            // File.WriteAllLines(MessageCsvFileName, MessageLine, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FEL vid export av föremål till CSV: {ex.Message}");
        }
    }

    public static List<User> LoadUsersFromCsv()
    {
        List<User> users = new List<User>();
        // 1. Returnera tom lista om filen saknas
        if (!File.Exists(UserCsvFileName))
        {
            users.Add(new User("testUser", "test", "test")); // User1 for testing
            users.Add(new User("albert", "beteman", "test")); // User2 for testing
            users.Add(new User("jarl", "jarleman", "test")); // User3 user for testing
            users.Add(new User("Cat_AYBABTU", "cat@z88.net", "test")); // User3 user for testing
            users.Add(new User("TheNegotiator", "zero_wing@trade.com", "test")); // User3 user for testing
            users.Add(new User("LoneWanderer", "vault101@trade.com", "test")); // User3 user for testing
            users.Add(new User("AYBABTU@trade.com", "1991", "test"));
            return users;
        }

        try
        {
            List<string> userLines = File.ReadAllLines(UserCsvFileName, Encoding.UTF8).Skip(1).ToList();
            List<Item> items = new List<Item>();
            List<string> itemLines = File.ReadAllLines(ItemsCsvFileName, Encoding.UTF8).Skip(1).ToList(); // cant use skip because it is a LINQ, SOLVE this
            List<string> messageLines = File.ReadAllLines(MessageCsvFileName, Encoding.UTF8).Skip(1).ToList();
            foreach (string line in userLines)
            {
                string[] parts = line.Split(',');

                if (parts.Length != 3) continue;

                string username = parts[0].Trim();
                string email = parts[1].Trim();
                string password = parts[2].Trim();

                User newUser = new User(username, email, password);

                users.Add(newUser);
            }
            // handle the item creation 
            foreach (User user in users)
            {

                foreach (string line in itemLines)
                {

                    string[] parts = line.Split(',');

                    if (user.Username == parts[0].Trim())
                    {
                        if (parts.Length != 4) continue;
                        string Name = parts[1].Trim();
                        string Description = parts[2].Trim();
                        string itemStatusString = parts[3].Trim();
                        user.AddItem(new Item(Name, Description, itemStatusString));
                    }


                }

                foreach (string message in messageLines)
                {
                    string[] messagePart = message.Split(',');
                    if (user.Username == messagePart[0].Trim())
                    {
                        if (messagePart.Length != 2) continue;
                        string messageText = messagePart[1].Trim();
                        user.message.Add(messageText);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR:  something happend on loading from the CSV: {ex.Message}. Returnerar tom lista.");
            return new List<User>();
        }

        return users;
    }



    public static void SaveTradesToCsv(List<Trade> trades)
    {

        List<string> PrintToTrades = new List<string>();
        // Lägg till header-raden
        string titleText = "Sender,Recivere,ItemsTrade,Status";
        PrintToTrades.Add(titleText);

        foreach (Trade trade in trades)
        {
            string handlingText = $"{trade.Sender.Username},{trade.Receiver.Username},[{trade.ItemTraded[0].Name},{trade.ItemTraded[1].Name}],{trade.Status}";
            PrintToTrades.Add(handlingText);
        }

        try
        {
            File.WriteAllLines(TradeCsvFileName, PrintToTrades, Encoding.UTF8);

            // Console.WriteLine($"Användardata exporterad till {TradeCsvFileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FEL vid export till CSV: {ex.Message}");
        }
    }


    public static void SaveAllItemsToCsv(List<string> itemLines)
    {
        try
        {
            File.WriteAllLines(ItemsCsvFileName, itemLines, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FEL vid export av föremål till CSV: {ex.Message}");
        }
    }

}
