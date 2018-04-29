using System;

using ReactiveUI;
using ReactiveUIifiedUwpTemplateStudioProject.Services;

using Windows.ApplicationModel;
using Windows.UI.Xaml;

namespace ReactiveUIifiedUwpTemplateStudioProject.ViewModels
{
    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : ReactiveObject, IRoutableViewModel
    {
        public IScreen HostScreen { get; }

        public string UrlPathSegment
        {
            get { return "settings-page"; }
        }

        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public ElementTheme ElementTheme
        {
            get { return _elementTheme; }
            set { this.RaiseAndSetIfChanged(ref _elementTheme, value); }
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get { return _versionDescription; }
            set { this.RaiseAndSetIfChanged(ref _versionDescription, value); }
        }

        private ReactiveCommand _switchThemeCommand;

        public ReactiveCommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = ReactiveCommand.CreateFromTask<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        public SettingsViewModel(IScreen screen)
        {
            HostScreen = screen;
        }

        public void Initialize()
        {
            VersionDescription = GetVersionDescription();
        }

        private string GetVersionDescription()
        {
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{package.DisplayName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
