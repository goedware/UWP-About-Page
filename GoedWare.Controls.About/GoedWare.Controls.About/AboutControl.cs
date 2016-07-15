using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using GoedWare.Controls.About.Items;

namespace GoedWare.Controls.About
{
    /// <summary>
    /// Control that will display an About page for your application
    /// You can specify which about items you want to display
    /// You can specify the about control and items in XAML or also in code-behind with dedicated item methods
    /// </summary>
    [TemplatePart(Name = "PART_RootGrid", Type = typeof(Grid))]
    [TemplatePart(Name = "PART_Image", Type = typeof(Image))]
    [TemplatePart(Name = "PART_Listview", Type = typeof(ListView))]
    [TemplatePart(Name = "PART_Description", Type = typeof(TextBlock))]
    //[ContentProperty(Name = "Items")]
    public class AboutControl : ContentControl
    {
        /// <summary>
        /// Gets or sets the logo in the header of the about page.
        /// </summary>
        /// <value>The logo in the header of the about page.</value>
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ImageSource" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(nameof(ImageSource), typeof(ImageSource), typeof(AboutControl), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the description of the about page.
        /// </summary>
        /// <value>The description of the about page.</value>
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Description" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(nameof(Description), typeof(string), typeof(AboutControl), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the height of the logo.
        /// </summary>
        /// <value>The height of the logo.</value>
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="ImageHeight" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register(nameof(ImageHeight), typeof(double), typeof(AboutControl), new PropertyMetadata(double.NaN));


        /// <summary>
        /// Gets or sets the collection of about items.
        /// </summary>
        /// <value>The collection of about items.</value>
        public ObservableCollection<AboutItem> Items
        {
            get { return (ObservableCollection<AboutItem>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        /// <summary>
        /// Identifier for the <see cref="Items" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<AboutItem>), typeof(AboutControl), new PropertyMetadata(new ObservableCollection<AboutItem>()));


        private Grid RootGrid { get; set; }
        private Image Image { get; set; }
        private ListView ListView { get; set; }
        private TextBlock DescriptionText { get; set; }

        public AboutControl()
        {
            this.DefaultStyleKey = typeof(AboutControl);

            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return;
            }
        }

        protected override void OnApplyTemplate()
        {
            if (this.ListView != null)
            {
                this.ListView.SelectionChanged -= OnSelectionChanged;
            }

            base.OnApplyTemplate();

            this.RootGrid = (Grid)this.GetTemplateChild("PART_RootGrid");
            this.Image = (Image)this.GetTemplateChild("PART_Image");
            this.ListView = (ListView)this.GetTemplateChild("PART_Listview");
            this.DescriptionText = (TextBlock)this.GetTemplateChild("PART_Description");

            if (this.ImageSource != null && this.Image != null)
            {
                this.Image.Source = this.ImageSource;
                this.Image.Height = this.ImageHeight;
            }

            if (!string.IsNullOrEmpty(this.Description) && this.DescriptionText != null)
                this.DescriptionText.Text = this.Description;

            if (this.Items.Any() && this.ListView != null)
            {
                this.ListView.SelectionChanged += OnSelectionChanged;
                this.ListView.ItemsSource = this.Items;
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!e.AddedItems.Any()) return;
            var aboutItem = e.AddedItems[0] as AboutItem;
            aboutItem?.Action?.Invoke();
            ((ListView) sender).SelectedIndex = -1;
        }

        private void ResetImage()
        {
            this.ImageSource = null;
        }

        #region Public Methods

        /// <summary>
        /// Set the logo of the about page
        /// </summary>
        /// <param name="source">Location of the logo image</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl SetImage(string source)
        {
            ResetImage();
            this.ImageSource = new BitmapImage(new Uri(source));
            return this;
        }

        /// <summary>
        /// Set the logo of the about page
        /// </summary>
        /// <param name="source">Stream resource of the logo image</param>
        /// <returns>The AboutPage control</returns>
        public async Task<AboutControl> SetImage(IRandomAccessStream source)
        {
            ResetImage();
            var bitmapImage = new BitmapImage();
            await bitmapImage.SetSourceAsync(source);
            this.ImageSource = bitmapImage;
            return this;
        }

        /// <summary>
        /// Set the description of the about page
        /// Is below the logo header
        /// </summary>
        /// <param name="description">The description for the about page</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl SetDescription(string description)
        {
            this.Description = description;
            return this;
        }

        /// <summary>
        /// Add a general about item object to the about page control
        /// </summary>
        /// <param name="item">AboutItem object</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddItem(AboutItem item)
        {
            if(item == null) throw new ArgumentNullException(nameof(item));
            this.Items.Add(item);
            return this;
        }

        /// <summary>
        /// Add a version item to the about page control
        /// Displays the current package version like: 'Version {Major}.{Minor}.{Build}'
        /// This item has no default icon;
        /// </summary>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddVersion()
        {
            var item = new VersionItem();
            AddItem(item);
            return this;
        }

        /// <summary>
        /// Add an e-mail item to the about page control that allows a user to send an e-mail to specified e-mail address
        /// </summary>
        /// <param name="address">E-mail To address</param>
        /// <param name="title">Override text to display on the screen next to the item icon</param>
        /// <param name="subject">Subject of the e-mail message</param>
        /// <param name="addDeviceAndDebugInformation">Add debug and device information to the body of the e-mail message</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddEmail(string address, string title = null, string subject = null, bool addDeviceAndDebugInformation = true)
        {
            var item = new EmailItem()
            {
                Value = address,
                AddDeviceAndDebugInformation = addDeviceAndDebugInformation
            };
            if (!string.IsNullOrEmpty(title)) item.Title = title;
            if (!string.IsNullOrEmpty(subject)) item.Subject = subject;
            AddItem(item);
            return this;
        }

        /// <summary>
        /// Add a website item to the about page control that links to a web page
        /// </summary>
        /// <param name="url">Url to navigate</param>
        /// <param name="title">Override text to display on the screen next to the item icon</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddWebsite(string url, string title = null)
        {
            var item = new WebsiteItem()
            {
                Value = url,
            };
            if (!string.IsNullOrEmpty(title)) item.Title = title;
            AddItem(item);
            return this;
        }

        /// <summary>
        /// Add a windows store item to the about page control that links to a Windows Store app review page
        /// </summary>
        /// <param name="familyName">Family name of the package</param>
        /// <param name="title">Override text to display on the screen next to the item icon</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddWindowsStore(string familyName = null, string title = null)
        {
            var item = new WindowsStoreItem()
            {
                Value = familyName,
            };
            if (!string.IsNullOrEmpty(title)) item.Title = title;
            AddItem(item);
            return this;
        }

        /// <summary>
        /// Add a play store item to the about page control that links to a Play Store app page
        /// </summary>
        /// <param name="packageName">Android package name</param>
        /// <param name="title">Override text to display on the screen next to the item icon</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddPlayStore(string packageName, string title = null)
        {
            var item = new PlayStoreItem()
            {
                Value = packageName,
            };
            if (!string.IsNullOrEmpty(title)) item.Title = title;
            AddItem(item);
            return this;
        }

        /// <summary>
        /// Add a twitter item to the about page control that links to a Twitter account
        /// </summary>
        /// <param name="account">Twitter account name</param>
        /// <param name="title">Override text to display on the screen next to the item icon</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddTwitter(string account, string title = null)
        {
            var item = new TwitterItem()
            {
                Value = account,
            };
            if (!string.IsNullOrEmpty(title)) item.Title = title;
            AddItem(item);
            return this;
        }

        /// <summary>
        /// Add a instagram item to the about page control that links to an Instagram account
        /// </summary>
        /// <param name="account">Instagram account name</param>
        /// <param name="title">Override text to display on the screen next to the item icon</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddInstagram(string account, string title = null)
        {
            var item = new InstagramItem()
            {
                Value = account,
            };
            if (!string.IsNullOrEmpty(title)) item.Title = title;
            AddItem(item);
            return this;
        }

        /// <summary>
        /// Add a youtube item to the about page control that links to a YouTube channel
        /// </summary>
        /// <param name="channel">Youtube channel id</param>
        /// <param name="title">Override text to display on the screen next to the item icon</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddYouTube(string channel, string title = null)
        {
            var item = new YouTubeItem()
            {
                Value = channel,
            };
            if (!string.IsNullOrEmpty(title)) item.Title = title;
            AddItem(item);
            return this;
        }

        /// <summary>
        /// Add a github item to the about page control that links to a GitHub account
        /// </summary>
        /// <param name="account">GitHub account name</param>
        /// <param name="title">Override text to display on the screen next to the item icon</param>
        /// <returns>The AboutPage control</returns>
        public AboutControl AddGitHub(string account, string title = null)
        {
            var item = new GitHubItem()
            {
                Value = account,
            };
            if (!string.IsNullOrEmpty(title)) item.Title = title;
            AddItem(item);
            return this;
        }

        #endregion

    }
}
