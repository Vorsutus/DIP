namespace DemoLibrary
{
    //changed to message send because maybe I want to send a message through a DB or a text?
    public interface IMessageSender
    {
        void SendMessage(IPerson person, string message);
    }
}