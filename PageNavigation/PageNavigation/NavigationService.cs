using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PageNavigation
{
    public class NavigationService : ViewModelBase, INavigationService
    {
        private readonly Dictionary<string, Uri> _pagesByKey;

        private string _currentPageKey;

        public string CurrentPageKey
        {
            get
            {
                return _currentPageKey;
            }

            private set
            {
                Set(() => CurrentPageKey, ref _currentPageKey, value);
            }
        }

        public NavigationService()
        {
            _pagesByKey = new Dictionary<string, Uri>();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, "Next");
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            var frame = GetDescendantFromName(Application.Current.MainWindow, "MainFrame") as Frame;

            if (frame != null)
            {

                frame.Source = _pagesByKey[pageKey];
            }

            CurrentPageKey = pageKey;
        }

        public void Configure(string key, Uri pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = pageType;
                }
                else
                {
                    _pagesByKey.Add(key, pageType);
                }
            }
        }

        public Uri getUri(string key)
        {
            if (_pagesByKey.ContainsKey(key))
            {
                return _pagesByKey[key];
            }

            return null;
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            if (parent == null)
            {
                for (int i = 0; i < 10; i++)
                {

                }
            }
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                var frameworkElement = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                if (frameworkElement != null)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }
    }
}
