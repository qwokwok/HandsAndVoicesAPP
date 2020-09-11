using Android.App;
using Android.Content;
using Firebase.Messaging;
using HandsAndVoices.Services;
using System.Linq;
using Xamarin.Forms;

namespace HandsAndVoices.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public static INotificationManager notificationManager = DependencyService.Get<INotificationManager>();
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            string messageBody = string.Empty;

            if (message.GetNotification() != null)
            {
                messageBody = message.GetNotification().Body;
            }

            // NOTE: test messages sent via the Azure portal will be received here
            else
            {
                messageBody = message.Data.Values.First();
            }

            // convert the incoming message to a local notification
            SendLocalNotification(messageBody);
        }

        public override void OnNewToken(string token)
        {
            // TODO: save token instance locally, or log if desired

            SendRegistrationToServer(token);
        }

        void SendLocalNotification(string body)
        {
            notificationManager.ScheduleNotification("new", body);
        }

        void SendRegistrationToServer(string token)
        {

        }
    }
}