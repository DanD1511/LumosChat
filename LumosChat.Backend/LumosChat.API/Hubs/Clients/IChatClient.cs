namespace LumosChat.API.Hubs.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(string userName, string message);
        Task UpdateUserList(List<string> users);
    }
}
