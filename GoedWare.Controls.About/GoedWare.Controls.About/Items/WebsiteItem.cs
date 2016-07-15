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

            this.Action = async () =>
            {
                if (string.IsNullOrEmpty(this.Value)) return;
                await LauncherService.BrowseToUrl(this.Value);
            };
        }
    }
}
