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
        // 1. Lista för Users (Users skrivs över vid varje körning)
        List<string> PrintToUsers = new List<string>() { "Username,Email,Passwor" };

        // 2. Lista för Items (Aggregerar ALLA items från ALLA users)
        // Denna lista är tom vid start av denna funktion, vilket förhindrar dubbletter.
        List<string> PrintToItems = new List<string>() { "Owner_Username,ItemName,Description" };

        foreach (User user in users)
        {
            string userHandlingText = $"{user.Username},{user.Email},{user.GetpassWord}";
            PrintToUsers.Add(userHandlingText);

            // We are agregrating the items lines for the user thats in the loop at the time.
            foreach (Item item in user.Items)
            {
                // Inkludera ägarens Username för att veta vem som äger föremålet
                string itemHandlingText = $"{user.Username},{item.Name},{item.Description}";
                PrintToItems.Add(itemHandlingText);
            }
        }

        // --- SAVE USERS ---
        try
        {
            // File.WriteAllLines garanterar overwrite, vilket förhindrar dubbletter mellan sessions
            File.WriteAllLines(UserCsvFileName, PrintToUsers, Encoding.UTF8);
            Console.WriteLine($"Användardata exporterad till {UserCsvFileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FEL vid export av användare till CSV: {ex.Message}");
        }

        // --- SAVE THE ITEMS ---
        // Call an dedicated function to write the Anropar en dedikerad funktion för att skriva över Item-filen helt.
        SaveAllItemsToCsv(PrintToItems);
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
            // Använd File.WriteAllLines för att Garantera att filen skrivs över helt 
            // vid varje körning. Detta eliminerar alla dubbletter från tidigare sessions.
            File.WriteAllLines(ItemsCsvFileName, itemLines, Encoding.UTF8);
            Console.WriteLine($"Föremålsdata exporterad till {ItemsCsvFileName}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FEL vid export av föremål till CSV: {ex.Message}");
        }
    }

}
