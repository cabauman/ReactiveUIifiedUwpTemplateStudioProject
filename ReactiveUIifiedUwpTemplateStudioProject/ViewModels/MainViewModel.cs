using System;

using ReactiveUI;

namespace ReactiveUIifiedUwpTemplateStudioProject.ViewModels
{
    public class MainViewModel : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment
        {
            get { return "main-page"; }
        }

        public MainViewModel(IScreen screen)
        {
            HostScreen = screen;
        }
    }
}
