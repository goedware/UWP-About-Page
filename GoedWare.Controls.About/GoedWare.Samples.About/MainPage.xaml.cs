using System;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GoedWare.Controls.About;
using GoedWare.Controls.About.Items;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GoedWare.Samples.About
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var aboutControl = new AboutControl()
                .SetImage("ms-appx:///Assets/goedware_logo.jpg", 100)
                .SetDescription("Write here something about your app and/or company")
                .AddVersion()
                .AddEmail("test@mail.com", "My app support")
                .AddWebsite("http://www.goedware.com")
                .AddWindowsStore()
                .AddTwitter("GoedWare")
                .AddFacebook("GoedWare")
                .AddGitHub("GoedWare")
                .AddInstagram("GoedWare")
                .AddYouTube("UCvJiYiBUbw4tmpRSZT2r1Hw")
                .AddPlayStore("com.whatsapp");

            var customItem = new AboutItem()
            {
                Title = "Custom about item",
                Foreground = new SolidColorBrush(Colors.BlueViolet),
                Value = "This is a custom about item",
                Icon = new SymbolIcon(Symbol.World),
                Action = async aboutItem =>
                {
                    var dialog = new MessageDialog(aboutItem.Value);
                    await dialog.ShowAsync();
                }
            };

            aboutControl.AddItem(customItem);

            this.AboutPageInCode.Content = aboutControl;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
           
        }
    }
}
