
namespace TradingSystem;

class Message
{

    public string Content;
    public User Recipient;
    public User Sender;
    public DateTime Timestamp;

    public Message(string content, User recipient, User sender)
    {
        Content = content;
        Recipient = recipient;
        Sender = sender;
        Timestamp = DateTime.Now;
    }
}


