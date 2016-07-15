using Windows.ApplicationModel;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that links to a Windows Store app review page
    /// </summary>
    public class WindowsStoreItem: AboutItem
    {
        public WindowsStoreItem()
        {
            this.Title = ResourceService.GetString("WindowsStoreItemTitle");
            this.Data = ResourceService.GetValue("WindowsStoreItemIconData");

            this.Action = async () =>
            {
                var familyName = string.IsNullOrEmpty(this.Value) ? Package.Current.Id.FamilyName : this.Value;
                await LauncherService.BrowseToUrl(string.Format(ResourceService.GetValue("WindowsStoreItemUrl"), familyName));
            };
        }
    }
}
