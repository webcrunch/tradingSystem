namespace TradingSystem;

class User
{
    public string Email;
    string _password;
    List<Item> Items = new List<Item>();
    public List<string> message = new List<string>();

    public User(string username, string password)
    {
        Email = username;
        _password = password;
    }

    public void AddItem(Item itemList)
    {
        Items.Add(itemList);
    }


    public void displayMessage()
    {
        if (message.Count == 0)
        {
            Console.WriteLine("No new messages.");
        }
        else
        {
            Console.WriteLine("Your messages:");
            for (int i = 0; i < message.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {message[i]}");
            }

            message.Clear();
        }
    }
    public Item? FindItem(string itemName)
    {
        return Items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
    }


    public void RemoveItem(Item itemToRemove)
    {
        // Använd Remove för att ta bort den specifika referensen till objektet
        Items.Remove(itemToRemove);
    }


    public void ShowItems()
    {
        foreach (var item in Items)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Name of User: {Email}");
            Console.WriteLine($"NameOfItem: {item.Name}");
            Console.WriteLine($"Description: {item.Description}");
        }
        Console.WriteLine("-----------------------------");
    }
    public bool TryLogin(string username, string password)
    {
        return username == Email && password == _password;
    }
}