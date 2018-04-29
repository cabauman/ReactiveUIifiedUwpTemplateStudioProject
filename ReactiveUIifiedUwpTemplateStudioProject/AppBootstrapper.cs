using ReactiveUI;
using ReactiveUIifiedUwpTemplateStudioProject.Services;
using ReactiveUIifiedUwpTemplateStudioProject.ViewModels;
using ReactiveUIifiedUwpTemplateStudioProject.Views;
using Splat;

namespace ReactiveUIifiedUwpTemplateStudioProject
{
    public class AppBootstrapper : ReactiveObject, IScreen
    {
        public AppBootstrapper(IMutableDependencyResolver dependencyResolver = null, RoutingState router = null)
        {
            Router = router ?? new RoutingState();
            dependencyResolver = dependencyResolver ?? Locator.CurrentMutable;

            RegisterParts(dependencyResolver);

            LogHost.Default.Level = LogLevel.Debug;

            Router.Navigate.Execute(new MainViewModel(this));
        }

        public RoutingState Router { get; private set; }

        private void RegisterParts(IMutableDependencyResolver dependencyResolver)
        {
            dependencyResolver.RegisterConstant(this, typeof(IScreen));
            dependencyResolver.RegisterConstant(new NavigationServiceEx(this), typeof(NavigationServiceEx));

            dependencyResolver.Register(() => new ShellPage(), typeof(IViewFor<ShellViewModel>));
            dependencyResolver.Register(() => new MainPage(), typeof(IViewFor<MainViewModel>));
            dependencyResolver.Register(() => new MasterDetailPage(), typeof(IViewFor<MasterDetailViewModel>));
            dependencyResolver.Register(() => new SettingsPage(), typeof(IViewFor<SettingsViewModel>));
        }
    }
}
