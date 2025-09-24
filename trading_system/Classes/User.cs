namespace TradingSystem;

public class User
{
    public string Username;
    string _password;

    public User(string username, string password)
    {
        Username = username;
        _password = password;
    }
}