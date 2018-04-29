using System;
using ReactiveUI;
using ReactiveUIifiedUwpTemplateStudioProject.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ReactiveUIifiedUwpTemplateStudioProject.Views
{
    public sealed partial class MainPage : IViewFor<MainViewModel>
    {
        public MainViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MainViewModel)value; }
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
