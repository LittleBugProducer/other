using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;

namespace PageNavigation.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public ICommand FirstPageCommand { get; set; }

        public ICommand SecondPageCommand { get; set; }

        public MainViewModel()
        {
            FirstPageCommand = new RelayCommand(First);
            SecondPageCommand = new RelayCommand(Second);
        }

        private void First()
        {
            var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            NavigationService service = (NavigationService)navigationService;
            Uri sendUri = service.getUri("First");
            Messenger.Default.Send<Uri>(sendUri, "FrameSourceName");
        }

        private void Second()
        {
            var navigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            NavigationService service = (NavigationService)navigationService;
            Uri sendUri = service.getUri("Second");
            Messenger.Default.Send<Uri>(sendUri, "FrameSourceName");
        }
        
    }
}