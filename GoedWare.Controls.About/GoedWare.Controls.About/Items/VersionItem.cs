using Windows.ApplicationModel;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that displays the current package version like: 'Version {Major}.{Minor}.{Build}'
    /// This item has no default icon;
    /// </summary>
    public class VersionItem: AboutItem
    {
        public VersionItem()
        {
            this.Icon = null;
            this.Data = null;
            this.Title =
                $"{ResourceService.GetString("VersionString")} {Package.Current.Id.Version.Major}.{Package.Current.Id.Version.Minor}.{Package.Current.Id.Version.Build}";
        }
    }
}
