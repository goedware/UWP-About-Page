using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// Base for all types of about items
    /// </summary>
    public class AboutItem
    {
        /// <summary>
        /// Gets or sets the title of the item (display text)
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the about item icon (default: ApplicationForegroundThemeBrush)
        /// </summary>
        public Brush Foreground { get; set; } = (SolidColorBrush) Application.Current.Resources["ApplicationForegroundThemeBrush"];

        /// <summary>
        /// Gets or sets the about item icon as a icon element (Possibilities: PathIcon, SymbolIcon, FontIcon, BitmapIcon)
        /// </summary>
        public IconElement Icon { get; set; }

        /// <summary>
        /// Gets or sets the about item icon as a Path (Example: M7.8,2H16.2C19.4,2 22,4.6 22,7.8V16.....)
        /// Path icons will scale on resize
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets value of the about item. Like id or address or url etc
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the action that will be invoked when the item is selected
        /// </summary>
        public Action<AboutItem> Action { get; set; }
    }
}
