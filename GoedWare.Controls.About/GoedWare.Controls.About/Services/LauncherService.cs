using System;
using System.Threading.Tasks;
using Windows.System;

namespace GoedWare.Controls.About.Services
{
    static class LauncherService
    {
        public static async Task BrowseToUrl(string url)
        {
            await Launcher.LaunchUriAsync(new Uri(url, UriKind.Absolute));
        }
    }
}
