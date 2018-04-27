using System;

using CommonServiceLocator;

using GalaSoft.MvvmLight.Ioc;

using ReactiveUIifiedUwpTemplateStudioProject.Services;
using ReactiveUIifiedUwpTemplateStudioProject.Views;

namespace ReactiveUIifiedUwpTemplateStudioProject.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            Register<MainViewModel, MainPage>();
        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
