using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace GoedWare.Controls.About.Services
{
    static class ResourceService
    {
        private static ResourceLoader _resourceStringLoader;
        private static ResourceLoader _resourceValueLoader;
        private static ResourceDictionary _resourceDictionary;

        public static string GetString(string name)
        {
            if (_resourceStringLoader == null)
                _resourceStringLoader = ResourceLoader.GetForCurrentView("GoedWare.Controls.About/Resources");
            return _resourceStringLoader.GetString(name);
        }

        public static string GetValue(string name)
        {
            if (_resourceValueLoader == null)
                _resourceValueLoader = ResourceLoader.GetForCurrentView("GoedWare.Controls.About/ControlResources");
            return _resourceValueLoader.GetString(name);
        }

        public static T GetDictionaryValue<T>(string resourceName)
        {
            if (_resourceDictionary == null)
            {
                _resourceDictionary = new ResourceDictionary();
                Application.LoadComponent(_resourceDictionary,
                    new Uri("ms-appx:///GoedWare.Controls.About/ResourceDictionary.xaml",
                        UriKind.RelativeOrAbsolute));
            }
            return (T) _resourceDictionary[resourceName];
        }
    }
}
