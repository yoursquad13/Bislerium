using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BisleriumBlog
{
    public sealed class NotificationsHub : Hub
    {
        public async Task SendNotification(string content)
        {
            await Clients.All.SendAsync("ReceiveNotification", content);
        }
    }
}
