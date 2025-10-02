namespace TradingSystem;
// Namespaces used in this file:
//
// using System.Collections.Generic;
//   → Provides generic collections like List<T>, used for storing users, items, trades, and messages.
//
// using System.IO;
//   → Provides file handling utilities (File.ReadAllLines, File.WriteAllLines, File.Exists),
//     used here to save and load CSV files.
//
// using System.Text;
//   → Provides text encoding support (Encoding.UTF8),
//     ensuring correct character encoding when reading/writing CSV files.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>
/// Provides methods for saving and loading users, items, messages, and trades
/// to and from CSV files. Handles persistence for the Trading System.
/// </summary>
class FileHandler
{
    /// <summary>
    /// File name for exported users.
    /// </summary>
    public const string UserCsvFileName = "users_export.csv";

    /// <summary>
    /// File name for exported trades.
    /// </summary>
    public const string TradeCsvFileName = "trades_export.csv";

    /// <summary>
    /// File name for exported items.
    /// </summary>
    public const string ItemsCsvFileName = "items_export.csv";

    /// <summary>
    /// File name for exported messages.
    /// </summary>
    public const string MessageCsvFileName = "message_export.csv";

    /// <summary>
    /// Saves all users, their items, and messages to CSV files.
    /// Overwrites existing files to avoid duplicates.
    /// </summary>
    /// <param name="users">The list of users to export.</param>
    public static void SaveUsersToCsv(List<User> users)
    {
        List<string> PrintToUsers = new() { "Username,Email,Password" };
        List<string> PrintToItems = new() { "Owner_Username,ItemName,Description,tradingLimbo" };
        List<string> PrintToMessage = new() { "messageOwner,message" };

        foreach (User user in users)
        {
            string userHandlingText = $"{user.Username},{user.Email},{user.GetpassWord()}";
            PrintToUsers.Add(userHandlingText);

            foreach (Item item in user.Items)
            {
                string itemHandlingText = $"{user.Username},{item.Name},{item.Description}, {item.TradingLimbo}";
                PrintToItems.Add(itemHandlingText);
            }

            foreach (string message in user.Messages)
            {
                string itemHandlingText = $"{user.Username},{message}";
                PrintToMessage.Add(itemHandlingText);
            }
        }

        try
        {
            File.WriteAllLines(UserCsvFileName, PrintToUsers, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: something happened when exporting users to CSV: {ex.Message}");
        }

        SaveAllItemsToCsv(PrintToItems);
        SaveAllMessagesToCsv(PrintToMessage);
    }

    /// <summary>
    /// Saves all messages to the message CSV file.
    /// </summary>
    /// <param name="MessageLine">The list of message lines to write.</param>
    public static void SaveAllMessagesToCsv(List<string> MessageLine)
    {
        try
        {
            File.WriteAllLines(MessageCsvFileName, MessageLine, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR exporting messages to CSV: {ex.Message}");
        }
    }

    /// <summary>
    /// Loads all users, their items, and messages from CSV files.
    /// If no user file exists, returns a set of test users.
    /// </summary>
    /// <returns>A list of loaded users.</returns>
    public static List<User> LoadUsersFromCsv()
    {
        List<User> users = new();

        if (!File.Exists(UserCsvFileName))
        {
            // Return test users if no file exists
            users.Add(new User("testUser", "test", "test"));
            users.Add(new User("albert", "beteman", "test"));
            users.Add(new User("jarl", "jarleman", "test"));
            users.Add(new User("Cat_AYBABTU", "cat@z88.net", "test"));
            users.Add(new User("TheNegotiator", "zero_wing@trade.com", "test"));
            users.Add(new User("LoneWanderer", "vault101@trade.com", "test"));
            users.Add(new User("AYBABTU@trade.com", "1991", "test"));
            return users;
        }

        try
        {
            List<string> userLines = File.ReadAllLines(UserCsvFileName, Encoding.UTF8).Skip(1).ToList();
            List<string> itemLines = File.ReadAllLines(ItemsCsvFileName, Encoding.UTF8).Skip(1).ToList();
            List<string> messageLines = File.ReadAllLines(MessageCsvFileName, Encoding.UTF8).Skip(1).ToList();

            foreach (string line in userLines)
            {
                string[] parts = line.Split(',');
                if (parts.Length != 3) continue;

                string username = parts[0].Trim();
                string email = parts[1].Trim();
                string password = parts[2].Trim();

                User newUser = new(username, email, password);
                users.Add(newUser);
            }

            foreach (User user in users)
            {
                foreach (string line in itemLines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length != 4) continue;

                    if (user.Username == parts[0].Trim())
                    {
                        string name = parts[1].Trim();
                        string description = parts[2].Trim();
                        string itemStatusString = parts[3].Trim();
                        user.AddItem(new Item(name, description, itemStatusString));
                    }
                }

                foreach (string message in messageLines)
                {
                    string[] messagePart = message.Split(',');
                    if (messagePart.Length != 2) continue;

                    if (user.Username == messagePart[0].Trim())
                    {
                        string messageText = messagePart[1].Trim();
                        user.Messages.Add(messageText);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR loading from CSV: {ex.Message}. Returning empty list.");
            return new List<User>();
        }

        return users;
    }

    /// <summary>
    /// Loads trades from the trade CSV file and reconstructs them with users and items.
    /// </summary>
    /// <param name="users">The list of users to match sender and receiver against.</param>
    /// <returns>A list of loaded trades.</returns>
    public static List<Trade> LoadTradeFRomCsv(List<User> users)
    {
        List<Trade> trades = new();

        if (!File.Exists(TradeCsvFileName))
        {
            return trades;
        }

        try
        {
            List<string> tradeLines = File.ReadAllLines(TradeCsvFileName, Encoding.UTF8).Skip(1).ToList();
            foreach (string line in tradeLines)
            {
                string[] parts = line.Split(',');
                if (parts.Length != 4) continue;

                User? sender = users.FirstOrDefault(user =>
                    user.Username.Equals(parts[0].Trim(), StringComparison.OrdinalIgnoreCase));

                User? receiver = users.FirstOrDefault(user =>
                    user.Username.Equals(parts[1].Trim(), StringComparison.OrdinalIgnoreCase));

                string[] itemTradeSplit = parts[2].Trim().Split('~');
                Item? itemToTrade = sender?.FindItem(itemTradeSplit[0]);
                Item? itemToReceive = receiver?.FindItem(itemTradeSplit[1]);
                Item[] newTradedItems = new Item[] { itemToTrade, itemToReceive };

                string statusStringTrade = parts[3].Trim();
                trades.Add(new Trade(sender, receiver, newTradedItems, statusStringTrade));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR loading trades from CSV: {ex.Message}");
        }

        return trades;
    }

    /// <summary>
    /// Saves all trades to the trade CSV file.
    /// </summary>
    /// <param name="trades">The list of trades to export.</param>
    public static void SaveTradesToCsv(List<Trade> trades)
    {
        List<string> PrintToTrades = new();
        PrintToTrades.Add("Sender,Receiver,ItemsTrade,Status");

        foreach (Trade trade in trades)
        {
            string handlingText = $"{trade.Sender.Username},{trade.Receiver.Username},{trade.ItemTraded[0].Name}~{trade.ItemTraded[1].Name},{trade.Status}";
            PrintToTrades.Add(handlingText);
        }

        try
        {
            File.WriteAllLines(TradeCsvFileName, PrintToTrades, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR exporting trades to CSV: {ex.Message}");
        }
    }

    /// <summary>
    /// Saves all items to the items CSV file.
    /// </summary>
    /// <param name="itemLines">The list of item lines to write.</param>
    public static void SaveAllItemsToCsv(List<string> itemLines)
    {
        try
        {
            File.WriteAllLines(ItemsCsvFileName, itemLines, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR exporting items to CSV: {ex.Message}");
        }
    }
}
