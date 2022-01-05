using System.Threading.Tasks;

namespace MentoriaChatLive.Hubs
{
    public interface ILiveChatHub
    {
        Task OnExitChatAsync(string username);
        Task OnEnterChatAsync(string username);
        Task OnNewMessageAsync(string username, string message);
    }
}
