//using System.Threading;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using HandsAndVoices.Services;

//namespace HandsAndVoices.Droid.Services
//{
//    [Service]
//    public class PeriodicService : Service
//    {
//        public static readonly System.Timers.Timer _interval = new System.Timers.Timer(1 * 10 * 1000);
//        public override IBinder OnBind(Intent intent)
//        {
//            return null;
//        }

//        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
//        {
//            // From shared code or in your PCL
//            _interval.Start();
//            _interval.Elapsed += BackgroundService.Check;

//            return StartCommandResult.NotSticky;
//        }
//    }
//}