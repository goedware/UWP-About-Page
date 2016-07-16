using System;
using System.Text.RegularExpressions;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Email;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;
using GoedWare.Controls.About.Services;

namespace GoedWare.Controls.About.Items
{
    /// <summary>
    /// About item that allows a user to send an e-mail to specified e-mail address
    /// </summary>
    public class EmailItem: AboutItem
    {
        public EmailItem()
        {
            this.Title = ResourceService.GetString("EmailItemTitle");
            this.Data = ResourceService.GetValue("EmailItemIconData");

            this.Action = async item =>
            {
                if (item.Value == null) throw new ArgumentNullException(nameof(item.Value));
                var regEx =
                    new Regex(
                        "[a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
                        RegexOptions.IgnoreCase);
                if (!regEx.IsMatch(item.Value)) throw new ArgumentException("Not valid e-mail address");

                var message = new EmailMessage();
                message.To.Add(new EmailRecipient(item.Value));
                message.Subject = ((EmailItem)item).Subject;

                if (this.AddDeviceAndDebugInformation)
                {
                    var deviceInfo = new EasClientDeviceInformation();
                    string sv = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
                    ulong v = ulong.Parse(sv);
                    ulong v1 = (v & 0xFFFF000000000000L) >> 48;
                    ulong v2 = (v & 0x0000FFFF00000000L) >> 32;
                    ulong v3 = (v & 0x00000000FFFF0000L) >> 16;
                    ulong v4 = (v & 0x000000000000FFFFL);

                    message.Body =
                        string.Format(ResourceService.GetString("EmailItemBody")
                            ,
                            Environment.NewLine,
                            string.Format("{0}.{1}.{2}",
                                Package.Current.Id.Version.Major,
                                Package.Current.Id.Version.Minor,
                                Package.Current.Id.Version.Build),
                            Package.Current.Id.Architecture,
                            Package.Current.InstalledDate,
                            Package.Current.InstalledLocation.Path,
                            AnalyticsInfo.VersionInfo.DeviceFamily,
                            $"{v1}.{v2}.{v3}.{v4}",
                            deviceInfo.FriendlyName,
                            deviceInfo.SystemManufacturer);
                }
                else
                {
                    message.Body = ResourceService.GetString("EmailItemBodySmall");
                }

                await EmailManager.ShowComposeNewEmailAsync(message);
            };
        }

        /// <summary>
        /// Subject of the e-mail message
        /// Default is 'Support'
        /// </summary>
        public string Subject { get; set; } = "Support";

        /// <summary>
        /// Option to add device and debug information to the body of the e-mail
        /// Default is True
        /// </summary>
        public bool AddDeviceAndDebugInformation { get; set; } = true;
    }
}
