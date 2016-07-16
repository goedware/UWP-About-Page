using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that links to a web page
    /// </summary>
    public class WebsiteItem: AboutItem
    {
        public WebsiteItem()
        {
            this.Title = ResourceService.GetString("WebsiteItemTitle");
            this.Data = ResourceService.GetValue("WebsiteItemIconData");

            this.Action = async item =>
            {
                if (string.IsNullOrEmpty(item.Value)) return;
                await LauncherService.BrowseToUrl(item.Value);
            };
        }
    }
}
