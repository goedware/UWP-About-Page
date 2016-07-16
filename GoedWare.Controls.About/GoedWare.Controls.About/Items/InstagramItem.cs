using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that links to an Instagram account
    /// </summary>
    public class InstagramItem : AboutItem
    {
        public InstagramItem()
        {
            this.Title = ResourceService.GetString("InstagramItemTitle");
            this.Foreground = ResourceService.GetDictionaryValue<SolidColorBrush>("InstagramColorBrush");
            this.Data = ResourceService.GetValue("InstagramItemIconData");

            this.Action = async item =>
            {
                if (string.IsNullOrEmpty(item.Value)) return;
                await LauncherService.BrowseToUrl(string.Format(ResourceService.GetValue("InstagramItemUrl"), item.Value));
            };
        }
        
    }
}
