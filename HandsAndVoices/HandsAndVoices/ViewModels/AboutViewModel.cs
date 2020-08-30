using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HandsAndVoices.ViewModels
{
    public class AboutViewModel
    {
        #region Properties
        public string WelcomeText { get; set; }
        public string TitleText { get; set; }
        public string SupportText { get; set; }
        public string JoinText { get; set; }
        public string MobileText { get; set; }
        #endregion

        public ICommand JoinCommand => new Command(async() =>
        {
            await OpenBrowser(new Uri("https://www.handsandvoices.org/about/join.htm"));
        });

        #region Constructors
        public AboutViewModel()
        {
            WelcomeText = "Welcome to the Hands & Voices family via the Parent Support App!\n\nThe app was designed to provide you with 90 days of support. Each day consists of:\n\n - Wisdom from a parent of a deaf / hard of hearing child\n\n - Wisdom from a deaf / hard of hearing adults\n\n - An article from Hands & Voices to read\n\n - A website / resource to explore\n\nWe hope that this app helps you navigate the parenting journey a bit easier with a plethora of support from others who have shared their journey, too.";
            TitleText = "About Hands & Voices:";
            SupportText = "Hands & Voices is dedicated to supporting families with children who are deaf and hard of hearing without a bias around communication modes or methodology. We're a parent-driven, non-profit organization providing families with the resources, networks, and information they need to improve communication access and educational outcomes for their children. Our outreach activities, parent/professional collaboration, and advocacy efforts are focused on enabling deaf and hard of hearing children to reach their highest potential.\n\nMost organizations serving families with deaf and hard of hearing children rally around common interests that usually include a philosophy of communication that is promoted by that group. Hands & Voices does not promote specific communication choices or methodologies, but we have information about them and can direct families or professionals to other fine support organizations for specific information like the Alexander Graham Bell Association or The American Society for Deaf Children, just to name a few.Our rallying points are areas of interest that are common to all people, but especially parents of deaf and hard of hearing children, and include these values..." +
                "\n\n- We all want the best for our children who are deaf or hard of hearing." +
                "\n\n- We deserve respect and honor for our role as parents / families.We require a beneficial, successful educational experience for our kids." +
                "\n\n- We need information from a wide variety of sources." +
                "\n\n- We want to know about opportunities and resources." +
                "\n\n- We need training & support to become effective advocates for our kids." +
                "\n\n- We are stronger united by our common interests than divided by differing communication choices." +
                "\n\n- We must lend our organized support to all kinds of efforts that promote our common interests--strength in numbers!";

            JoinText = "To become a member of Hands & Voices, you can join our efforts by subscribing here";

            MobileText = "This app was developed in collaboration with the Mobile App class at RIT NTID in Rochester, New York, directed by Karen Putz.";
        }
        #endregion

        public async Task OpenBrowser(Uri uri)
        {
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
    }
}
