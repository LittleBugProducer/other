/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:PageNavigation.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
namespace PageNavigation.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FirstViewModel>();
            SimpleIoc.Default.Register<SecondViewModel>();

            var navigationService = CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
        }

        private static INavigationService CreateNavigationService()
        {
            var nav = new NavigationService();

            var navigationService = new NavigationService();
            navigationService.Configure("First", new Uri("/PageNavigation;component/views/FirstPage.xaml", UriKind.Relative));
            navigationService.Configure("Second", new Uri("/PageNavigation;component/views/SecondPage.xaml", UriKind.Relative));            
            return navigationService;
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public FirstViewModel First
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FirstViewModel>();
            }
        }

        public SecondViewModel Second
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SecondViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}