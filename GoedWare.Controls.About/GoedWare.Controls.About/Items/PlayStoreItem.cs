using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that links to a Play Store app page
    /// </summary>
    public class PlayStoreItem : AboutItem
    {
        public PlayStoreItem()
        {
            this.Title = ResourceService.GetString("PlayStoreItemTitle");
            this.Foreground = ResourceService.GetDictionaryValue<SolidColorBrush>("PlayStoreColorBrush");
            this.Data = ResourceService.GetValue("PlayStoreItemIconData");

            this.Action = async () =>
            {
                if (string.IsNullOrEmpty(this.Value)) return;
                await LauncherService.BrowseToUrl(string.Format(ResourceService.GetValue("PlayStoreItemUrl"), this.Value));
            };
        }
        
    }
}
