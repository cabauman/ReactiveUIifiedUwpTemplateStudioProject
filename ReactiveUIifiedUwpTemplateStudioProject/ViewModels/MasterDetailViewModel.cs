using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Toolkit.Uwp.UI.Controls;
using ReactiveUI;
using ReactiveUIifiedUwpTemplateStudioProject.Models;
using ReactiveUIifiedUwpTemplateStudioProject.Services;

namespace ReactiveUIifiedUwpTemplateStudioProject.ViewModels
{
    public class MasterDetailViewModel : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment
        {
            get { return "master-detail-page"; }
        }

        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { this.RaiseAndSetIfChanged(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public MasterDetailViewModel(IScreen screen)
        {
            HostScreen = screen;
        }

        public async Task LoadDataAsync(MasterDetailsViewState viewState)
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetSampleModelDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (viewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
