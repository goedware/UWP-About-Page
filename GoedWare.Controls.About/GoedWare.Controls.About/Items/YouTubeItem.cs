using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that links to a YouTube channel
    /// </summary>
    public class YouTubeItem : AboutItem
    {
        public YouTubeItem()
        {
            this.Title = ResourceService.GetString("YouTubeItemTitle");
            this.Foreground = ResourceService.GetDictionaryValue<SolidColorBrush>("YouTubeColorBrush");
            this.Data = ResourceService.GetValue("YouTubeItemIconData");

            this.Action = async item =>
            {
                if (string.IsNullOrEmpty(item.Value)) return;
                await LauncherService.BrowseToUrl(string.Format(ResourceService.GetValue("YouTubeItemUrl"), item.Value));
            };
        }
        
    }
}
