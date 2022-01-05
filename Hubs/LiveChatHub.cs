using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace MentoriaChatLive.Hubs
{
    public class LiveChatHub : Hub<ILiveChatHub>, ILiveChatHub
    {
        private const string LiveChatGroup = "LiveChatGroup";
        public override async Task OnConnectedAsync(){
            await Groups.AddToGroupAsync(Context.ConnectionId, LiveChatGroup);
        }
        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, LiveChatGroup);
        }

        public async Task OnEnterChatAsync(string username)
        {
            await Clients.Groups(LiveChatGroup).OnEnterChatAsync(username);
        }

        public async Task OnExitChatAsync(string username)
        {
            await Clients.OthersInGroup(LiveChatGroup).OnExitChatAsync(username);
        }

        public async Task OnNewMessageAsync(string username, string message)
        {
            await Clients.OthersInGroup(LiveChatGroup).OnNewMessageAsync(username, message);
        }
    }
}
