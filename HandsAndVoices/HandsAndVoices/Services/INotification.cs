using System;

namespace HandsAndVoices.Services
{
    public interface INotification
    {
        void CreateNotification(String title, String message);
    }
}
