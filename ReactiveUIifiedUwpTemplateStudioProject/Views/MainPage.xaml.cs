using System;

using ReactiveUIifiedUwpTemplateStudioProject.ViewModels;

using Windows.UI.Xaml.Controls;

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
