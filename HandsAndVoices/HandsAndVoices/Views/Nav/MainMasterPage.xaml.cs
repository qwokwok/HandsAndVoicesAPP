using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPage : Xamarin.Forms.MasterDetailPage
    {
        public int CurrentIndex;
        public MainMasterPage()
        {
            InitializeComponent();
            masterPage.MasterPageNavListView.ItemTapped += MasterPageNavListView_ItemTapped;
            //homepage is a default page so it would be always 0 index when the app is opened
            CurrentIndex = 0;
        }

        private async void MasterPageNavListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MasterPageImgItem;
            if (item != null)
            {
                switch (e.ItemIndex)
                {
                    case 2: App.Section = "Article"; break;
                    case 3: App.Section = "Quote"; break;
                    case 4: App.Section = "Resource"; break;
                }

                //prevent to reload a page that is already loaded while selecting the same page for performance purpose
                if (CurrentIndex == e.ItemIndex)
                    IsPresented = false;

                else 
                {
                    Detail = new TransparentNavigationPage((Xamarin.Forms.Page)Activator.CreateInstance(item.TargetType)) { BarTextColor = Color.White };

                    // lagspike less when sliding left/right
                    await Task.Delay(25);
                    CurrentIndex = e.ItemIndex;
                    masterPage.MasterPageNavListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }
    }
}