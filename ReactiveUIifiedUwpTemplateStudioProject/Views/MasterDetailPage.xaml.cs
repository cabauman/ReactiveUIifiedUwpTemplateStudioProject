using System;
using ReactiveUI;
using ReactiveUIifiedUwpTemplateStudioProject.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReactiveUIifiedUwpTemplateStudioProject.Views
{
    public sealed partial class MasterDetailPage : IViewFor<MasterDetailViewModel>
    {
        public MasterDetailViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MasterDetailViewModel)value; }
        }

        public MasterDetailPage()
        {
            InitializeComponent();
            Loaded += MasterDetailPage_Loaded;
        }

        private async void MasterDetailPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}
