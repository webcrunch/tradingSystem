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

    public static void SaveUsersToCsv(List<User> users)
    {
        List<string> PrintToUsers = new List<string>();

        // Lägg till header-raden
        string titleText = "Username,Email,Password";
        PrintToUsers.Add(titleText);

        foreach (User user in users)
        {
            string handlingText = $"{user.Username},{user.Email},{user.GetpassWord()}";
            PrintToUsers.Add(handlingText);
            SaveItemsToCsv(user.Items, user.Username);
        }

        try
        {
            // 1. Skicka filnamnet ("users_export.csv")
            // 2. Skicka listan med strängar (PrintToUsers)
            File.WriteAllLines(UserCsvFileName, PrintToUsers, Encoding.UTF8);

            Console.WriteLine($"Användardata exporterad till {UserCsvFileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FEL vid export till CSV: {ex.Message}");
        }
    }

    public static void SaveTradesToCsv(List<Trade> trades)
    {

        List<string> PrintToTrades = new List<string>();
        // Lägg till header-raden
        string titleText = "Sender,Recivere,ItemsTrade,Status";
        PrintToTrades.Add(titleText);

        foreach (Trade trade in trades)
        {
            string handlingText = $"{trade.Sender.Username},{trade.Sender.Username},[{trade.ItemTraded[0].Name},{trade.ItemTraded[1].Name}],{trade.Status}";
            PrintToTrades.Add(handlingText);
        }

        try
        {
            File.WriteAllLines(TradeCsvFileName, PrintToTrades, Encoding.UTF8);

            Console.WriteLine($"Användardata exporterad till {TradeCsvFileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FEL vid export till CSV: {ex.Message}");
        }
    }

    public static void SaveItemsToCsv(List<Item> items, string user)
    {
        List<string> PrintToItems = new List<string>() { "User,Name,Description" };
        // Lägg till header-raden

        foreach (Item item in items)
        {
            // string handlingText = $"{item.Name},{item.Description}";
            string handlingText = " Dddddddddddddd";
            PrintToItems.Add(handlingText);
        }
        try
        {
            File.WriteAllLines(ItemsCsvFileName, PrintToItems, Encoding.UTF8);

            Console.WriteLine($"Användardata exporterad till {ItemsCsvFileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FEL vid export till CSV: {ex.Message}");
        }
    }
}
