using Microsoft.AspNetCore.SignalR;

namespace Hackerspace.Server.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", "Server", $"{Context.ConnectionId} joined the chat");
            await base.OnConnectedAsync();
        }   

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("ReceiveMessage", "Server", $"{Context.ConnectionId} left the chat");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendPrivateMessage(string user, string message)
        {
            await Clients.User(user).SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendToGroup(string group, string user, string message)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);
            await Clients.Group(group).SendAsync("ReceiveMessage", "Server", $"{Context.ConnectionId} joined {group}");
        }

        public async Task LeaveGroup(string group)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", "Server", $"{Context.ConnectionId} left {group}");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        }

        public async Task SendToOthersInGroup(string group, string user, string message)
        {
            await Clients.OthersInGroup(group).SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendToConnection(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }

        public async Task SendToConnections(List<string> connectionIds, string message)
        {
            await Clients.Clients(connectionIds).SendAsync("ReceiveMessage", message);
        }

        public async Task SendToAllExceptConnection(string connectionId, string message)
        {
            await Clients.AllExcept(connectionId).SendAsync("ReceiveMessage", message);
        }

        public async Task SendToAllExceptConnections(List<string> connectionIds, string message)
        {
            await Clients.AllExcept(connectionIds).SendAsync("ReceiveMessage", message);
        }

    }
}
