// if am creating a namespace called TradingSystem.
namespace TradingSystem;
// I have create a class that i have called User. It is for handling the users in the system.
// The class is public so it can be accessed from other classes. 
class User
{


    /// <summary>
    /// Represents a user in the trading system.
    /// I keep login credentials, items, and messages together here
    /// so that everything related to a user is managed in one place.
    /// I am choose to save all the messages and items for that user in own lists.
    /// I think that is making easier access and handling the ownership of messages and items. 
    /// I am handling password as a <see langword="private"/> because there is no need for other to access that. 
    /// But i need to fetch the data  for save to file. This could be handled with hash but had not time for that 
    /// this time.
    /// I am applying a couple of functions that is handling finding removing and showing items. 
    /// And to handle check password and username for login.  
    /// </summary>

    /// <summary>
    /// The user's email address.
    /// Used both as contact information and for login.
    /// </summary>
    public string Email;
    /// <summary>
    /// The username chosen by the user.
    /// This is what is displayed publicly in the system.
    /// </summary>
    public string Username;

    private string _password;
    /// <summary>
    /// A collection of items owned by the user.
    /// A list is used so items can be added and removed dynamically.
    /// </summary>
    public List<Item> Items = new List<Item>();
    /// <summary>
    /// A list of messages received by the user.
    /// Messages are stored here until they are displayed, then cleared.
    /// </summary>
    public List<string> Messages = new List<string>();

    /// <summary>
    /// Creates a new user with username, email, and password.
    /// The password is stored privately to avoid direct access.
    /// </summary>
    public User(string username, string email, string password)
    {
        Email = email;
        Username = username;
        _password = password;
    }

    /// <summary>
    /// Adds a new <see cref="Item"/> to the user's collection.
    /// </summary>
    public void AddItem(Item itemList)
    {
        Items.Add(itemList);
    }
    /// <summary>
    /// Returns the user's password.
    /// I use a method instead of exposing the field directly
    /// so I can control access in the future if needed.
    /// I need to get the password when i am saving data to the file
    /// nice to use linq here instead:         
    /// public string GetPassword() => _password;
    /// </summary>
    public string GetpassWord()
    {
        return _password;
    }

    /// <summary>
    /// Displays all messages for the user.
    /// After showing them, the list is cleared to simulate "read" messages.
    /// Have rules depending if the list is empthy or not. I am using the built in function for the array Any.
    /// It check if there is anything in the list then it loop thorugh all the messages in the list and displauy on the screen. 
    /// Otherwise it will print a message that there is no messages
    /// </summary>
    public void displayMessage()
    {
        if (Messages.Any())
        {
            Console.WriteLine("Your messages:");
            for (int i = 0; i < Messages.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Messages[i]}");
            }
            Messages.Clear();
        }
        else
        {
            Console.WriteLine("No new messages.");
        }
    }


    /// <summary>
    /// Finds the first <see cref="Item"/> in the collection whose Name matches the given itemName.
    /// The comparison is case-insensitive (OrdinalIgnoreCase), so "Albert" and "albert" are treated as equal.
    /// Returns null if no matching item is found.
    /// </summary>
    public Item? FindItem(string itemName)
    {

        return Items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Removes the specified <see cref="Item"/> from the user's collection.
    /// Typically used when a trade is accepted and items are exchanged.
    /// Here could we use a shorter linq handling: 
    /// public void RemoveItem(Item itemToRemove) => Items.Remove(itemToRemove);
    /// </summary>
    public void RemoveItem(Item itemToRemove)
    {
        // use the Remove function to remve a specific item fro the user
        // using the Remove function in lists. And remove the current item
        // We are using it when it is an accepted trade. We do a remove and add for each item. 
        Items.Remove(itemToRemove);
    }


    /// <summary>
    /// Displays all items owned by the user.
    /// If <paramref name="checkAllOrAvailableTrade"/> is true, shows all items.
    /// If false, only shows items available for trade.


    ///  This example is for the current active user:
    ///      Your items:
    ///  -----------------------------
    ///  Name of User: testUser
    ///  NameOfItem: Böcker
    ///  Description: 32 stycken nalle puh böcker
    ///  -----------------------------
    ///  Name of User: testUser
    ///  NameOfItem: handskar
    ///  Description: 2 par elefanthanskar
    ///  ----------------------------- */
    /// </summary>

    public void ShowItems(bool checkAllORAvailableTrade = true)
    {
        foreach (Item item in Items)
        {
            if (checkAllORAvailableTrade)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Name of User: {Username}");
                Console.WriteLine($"NameOfItem: {item.Name}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Available for Trade: {(item.TradingLimbo == Item.TradingStatus.None ? "Yes" : "No")}");
            }
            else if (item.TradingLimbo == Item.TradingStatus.None)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Name of User: {Username}");
                Console.WriteLine($"NameOfItem: {item.Name}");
                Console.WriteLine($"Description: {item.Description}");
            }

        }
        Console.WriteLine("-----------------------------");
    }
    /// <summary>
    /// Checks if the user has at least one item available for trade.
    /// Useful to quickly determine if the user can participate in trading.

    /// This one-two liners was nice:
    /// public bool ItemForTrade() =>
    ///     Items.Any(item => item.TradingLimbo == Item.TradingStatus.None);
    /// Explain the linq. first line we have as always data type that we want to return and the method name
    /// and in the second one there is a check in the items array for all the itmes that has the status of the trading as none
    /// </summary>
    public bool ItemForTrade()
    {
        List<Item> checkAvailableItem = new List<Item>();
        if (Items.Count > 0)
        {
            foreach (Item item in Items)
            {
                if (item.TradingLimbo == Item.TradingStatus.None)
                {
                    checkAvailableItem.Add(item);
                }
            }
        }
        else
        {
            return false;
        }
        return checkAvailableItem.Count > 0 ? true : false;
    }
    /// <summary>
    /// Validates login credentials against the user's stored email and password.
    /// </summary>
    public bool TryLogin(string email, string password)
    {
        return email == Email && password == _password;
    }

    /// <summary>
    /// Counts how many items the user has that are available for trade.
    /// Filters by status first, then counts the results.
    /// </summary>
    public int getAmoutOfItemsForUser()
    {
        // 1. Where: Filtrera Items där statusen ÄR None.
        // 2. Count(): Räkna antalet i den filtrerade listan.
        return Items.Where(item => item.TradingLimbo == Item.TradingStatus.None)
                    .Count();
    }
}