using LumosChat.API.Hubs.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent; // <--- Necesario para el diccionario thread-safe

namespace LumosChat.API.Hubs;

[Authorize]
public class ChatHub : Hub<IChatClient>
{
    private static readonly ConcurrentDictionary<string, string> _onlineUsers = new();
    public override async Task OnConnectedAsync()
    {
        string username = Context.User?.Identity?.Name ?? "Anónimo";
        string connectionId = Context.ConnectionId;

        _onlineUsers.TryAdd(connectionId, username);

        await BroadcastUserList();

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        string connectionId = Context.ConnectionId;

        _onlineUsers.TryRemove(connectionId, out _);
        await BroadcastUserList();

        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(string message)
    {
        string username = _onlineUsers.TryGetValue(Context.ConnectionId, out var name) ? name : "Anónimo";
        await Clients.All.ReceiveMessage(username, message);
    }

    private async Task BroadcastUserList()
    {
        var distinctUsers = _onlineUsers.Values.Distinct().OrderBy(u => u).ToList();
        await Clients.All.UpdateUserList(distinctUsers);
    }
}