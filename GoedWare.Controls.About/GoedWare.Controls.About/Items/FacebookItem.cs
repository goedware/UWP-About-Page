using Windows.UI.Xaml.Media;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that links to a Facebook account
    /// </summary>
    public class FacebookItem: AboutItem
    {
        public FacebookItem()
        {
            this.Title = ResourceService.GetString("FacebookItemTitle");
            this.Foreground = ResourceService.GetDictionaryValue<SolidColorBrush>("FacebookColorBrush");
            this.Data = ResourceService.GetValue("FacebookItemIconData");

            this.Action = async item => 
            {
                if (string.IsNullOrEmpty(item.Value)) return;
                await LauncherService.BrowseToUrl(string.Format(ResourceService.GetValue("FacebookItemUrl"), item.Value));
            };
        }
        
    }
}
