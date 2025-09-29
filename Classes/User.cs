// if am creating a namespace called TradingSystem.
namespace TradingSystem;
// I have create a class that i have called User. It is for handling the users in the system.
// The class is public so it can be accessed from other classes. 
class User
{

    /* There is three properties in this class.
     Email, password and a list of items.
     I have also create a constructor that takes in two parameters.
     I have created six methods in this class. They are:
     AddItem, displayMessage, FindItem, RemoveItem, ShowItems and TryLogin
     # AddItem takes in an item and adds it to the list of items.
     # displayMessage shows all the messages the user has received.
     # FindItem takes in a string and returns an item if it finds one with the same name as the string.
     # RemoveItem takes in an item and removes it from the list of items. 
     # ShowItems shows all the items the user has.
     # TryLogin takes in a username and password and returns true if they match the users email and password.
    */
    public string Email;
    public string Username;
    string _password;
    public List<Item> Items = new List<Item>();
    public List<string> message = new List<string>();

    public User(string username, string email, string password)
    {
        Email = email;
        Username = username;
        _password = password;
    }

    public void AddItem(Item itemList)
    {
        Items.Add(itemList);
    }

    public string GetpassWord()
    {
        return _password;
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
        // here we are searcing for the item. We do a check if the itemName we are sending to the list
        // is found. The StringComparison.OrdinalIgnoreCase does not mind the if it is uppercase, lowecase
        // or mixxed. So it only checks if the spelling is the same. example: 
        return Items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
    }


    public void RemoveItem(Item itemToRemove)
    {
        // use the Remove function to remve a specific item fro the user
        // using the Remove function in lists. And remove the current item
        // We are using it when it is an accepted trade. We do a remove and add for each item. 
        Items.Remove(itemToRemove);
    }


    /* created a function that will loop trough all the items from the user that calls the function. 
     for example: active_user.showItems();
     Or in a for loop we could call it like this: 
       foreach (User user in users)
     {
         if (user == active_user) continue; // Skip the active user's items
         -- user.ShowItems(); --
     }*/

    /* It will look like this for example: 
     The example is for the current active user:
         Your items:
     -----------------------------
     Name of User: testUser
     NameOfItem: Böcker
     Description: 32 stycken nalle puh böcker
     -----------------------------
     Name of User: testUser
     NameOfItem: handskar
     Description: 2 par elefanthanskar
     ----------------------------- */
    public void ShowItems()
    {
        foreach (Item item in Items)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Name of User: {Username}");
            Console.WriteLine($"NameOfItem: {item.Name}");
            Console.WriteLine($"Description: {item.Description}");
        }
        Console.WriteLine("-----------------------------");
    }
    // Function that send true if the user input right email and password
    public bool TryLogin(string email, string password)
    {
        return email == Email && password == _password;
    }
}