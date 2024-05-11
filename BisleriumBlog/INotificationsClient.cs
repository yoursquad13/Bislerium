namespace BisleriumBlog
{
    public interface INotificationsClient
    {
        Task ReceiveNotification(string content);
    }
}
