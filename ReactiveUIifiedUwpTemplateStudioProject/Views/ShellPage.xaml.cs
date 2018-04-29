using System;
using ReactiveUI;
using ReactiveUIifiedUwpTemplateStudioProject.Services;
using ReactiveUIifiedUwpTemplateStudioProject.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ReactiveUIifiedUwpTemplateStudioProject.Views
{
    public sealed partial class ShellPage : IViewFor<ShellViewModel>
    {
        public ShellViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (ShellViewModel)value; }
        }

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame);
        }
    }
}
