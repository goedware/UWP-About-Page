using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that links to a GitHub account
    /// </summary>
    public class GitHubItem : AboutItem
    {
        public GitHubItem()
        {
            this.Title = ResourceService.GetString("GithubItemTitle");

            this.Foreground = ResourceService.GetDictionaryValue<SolidColorBrush>("GitHubColorBrush");
            this.Data = ResourceService.GetValue("GitHubItemIconData");
            this.Action = async item =>
            {
                if (string.IsNullOrEmpty(item.Value)) return;
                await LauncherService.BrowseToUrl(string.Format(ResourceService.GetValue("GitHubItemUrl"), item.Value));
            };
        }
        
    }
}
