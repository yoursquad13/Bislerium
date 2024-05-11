using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BisleriumBlog
{
    public sealed class NotificationsHub : Hub
    {
        public async Task SendNotification(Notification noti)
        {
            var users = new string[] { noti.ToUserId, noti.FromUserId };
            await Clients.Users(users).SendAsync("ReceiveNotification", noti);
        }
    }
}
