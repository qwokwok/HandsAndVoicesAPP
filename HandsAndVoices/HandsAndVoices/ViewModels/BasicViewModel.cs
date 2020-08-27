using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HandsAndVoices.ViewModels
{
    public class BasicViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Pass in a single property to cause a UI update.
        /// </summary>
        protected void NotifyPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
