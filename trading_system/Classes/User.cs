namespace TradingSystem;

class User
{
    public string Email;
    string _password;
    List<Item> Items = new List<Item>();
    public User(string username, string password)
    {
        Email = username;
        _password = password;
    }

    public void AddItem(Item itemList)
    {
        Items.Add(itemList);
    }

    public void ShowItems(List<Item> items)
    {
        foreach (var item in Items)
        {
            Console.WriteLine($"Name: {item.Name}, Description: {item.Description}");
        }
    }
    public bool TryLogin(string username, string password)
    {
        return username == Email && password == _password;
    }
}