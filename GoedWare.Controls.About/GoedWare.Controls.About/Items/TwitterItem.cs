using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that links to a Twitter account
    /// </summary>
    public class TwitterItem : AboutItem
    {
        public TwitterItem()
        {
            this.Title = ResourceService.GetString("TwitterItemTitle");
            this.Foreground = ResourceService.GetDictionaryValue<SolidColorBrush>("TwitterColorBrush");
            this.Data = ResourceService.GetValue("TwitterItemIconData");

            this.Action = async item =>
            {
                if (string.IsNullOrEmpty(item.Value)) return;
                await LauncherService.BrowseToUrl(string.Format(ResourceService.GetValue("TwitterItemUrl"), item.Value));
            };
        }
        
    }
}
