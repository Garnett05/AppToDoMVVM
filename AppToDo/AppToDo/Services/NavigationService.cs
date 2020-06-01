using AppToDo.ViewModels;
using AppToDo.Views;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppToDo.Services
{
    public interface INavigationService
    {
        Task PushAsync<TViewModel>(object param = null) where TViewModel : BaseViewModel;
        Task PopAsync();
    }
    public class NavigationService : INavigationService
    {
        private Func<INavigation> _navigation;
        private IComponentContext _container;
        private readonly Dictionary<Type, Type> _pageMap = new Dictionary<Type, Type>
        {
            {typeof(ToDoViewModel), typeof(ToDoView) }
        };

        public NavigationService(Func<INavigation> navigation, IComponentContext container)
        {
            _navigation = navigation;
            _container = container;
        }

        public async Task PopAsync()
        {
            await _navigation().PopAsync();
        }

        public async Task PushAsync<TViewModel>(object param = null) where TViewModel : BaseViewModel
        {
            var pageType = _pageMap[typeof(TViewModel)];
            Page page = _container.Resolve(pageType) as Page;
            await _navigation().PushAsync(page);
            await (page.BindingContext as BaseViewModel).InitializeAsync(param);
        }
    }
}
