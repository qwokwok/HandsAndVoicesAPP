using HandsAndVoices.iOS.Notification;
using HandsAndVoices.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificationHelper))]
namespace HandsAndVoices.iOS.Notification
{
    class NotificationHelper : INotification
    {
        public void CreateNotification(string title, string message)
        {
            new NotificationDelegate().RegisterNotification(title, message);
        }
    }
}