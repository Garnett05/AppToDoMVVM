using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppToDo.Views;
using Autofac;
using System.Reflection;
using AppToDo.Services;

namespace AppToDo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //class used for build the registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                .AsImplementedInterfaces()
                .AsSelf();

            NavigationPage navigationPage = null;
            Func<INavigation> navigationFunc = () =>
            {
                return navigationPage.Navigation;
            };
            builder.RegisterType<NavigationService>().As<INavigationService>()
                .WithParameter("navigation", navigationFunc);
            //get container
            var container = builder.Build();
            navigationPage = new NavigationPage(container.Resolve<ToDoView>());
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
