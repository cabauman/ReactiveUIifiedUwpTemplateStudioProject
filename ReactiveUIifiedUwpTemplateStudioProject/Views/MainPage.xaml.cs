using System;

using Windows.UI.Xaml.Controls;

using ReactiveUIifiedUwpTemplateStudioProject.ViewModels;

namespace ReactiveUIifiedUwpTemplateStudioProject.Views
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel ViewModel
        {
            get { return DataContext as MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
