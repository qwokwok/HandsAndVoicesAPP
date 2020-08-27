﻿using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HandsAndVoices.Views.Nav
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPage : MasterDetailPage
    {
        public int CurrentIndex;
        public static string Title { get; set;}
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
                //prevent to reload a page that is already loaded while selecting the same page for performance purpose
                if(CurrentIndex == e.ItemIndex)
                    IsPresented = false;

                else 
                {
                    switch(e.ItemIndex)
                    {
                        case 1: Title = "Articles"; break;
                        case 3: Title = "Resources"; break;
                    }

                    Detail = new TransparentNavigationPage((Page)Activator.CreateInstance(item.TargetType));

                    // lagspike less when sliding left/right
                    await Task.Delay(75);
                    CurrentIndex = e.ItemIndex;
                    masterPage.MasterPageNavListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }

        // Disable hardware back button while on this master detail page top prevent close an app easily on accident
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}