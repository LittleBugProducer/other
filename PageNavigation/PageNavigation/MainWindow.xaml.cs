using System.Windows;
using PageNavigation.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace PageNavigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<Uri>(this, "FrameSourceName", ChangeFrameSource);
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
        private void ChangeFrameSource(Uri uri)
        {
            this.MainFrame.Source = uri;
        }
    }
}