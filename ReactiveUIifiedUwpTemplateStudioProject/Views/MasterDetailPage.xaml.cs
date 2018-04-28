﻿using System;

using ReactiveUIifiedUwpTemplateStudioProject.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ReactiveUIifiedUwpTemplateStudioProject.Views
{
    public sealed partial class MasterDetailPage : Page
    {
        private MasterDetailViewModel ViewModel
        {
            get { return DataContext as MasterDetailViewModel; }
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
