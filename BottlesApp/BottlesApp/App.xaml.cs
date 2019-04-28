using BottlesApp.Services;
using BottlesApp.ViewModels;
using BottlesApp.Views;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Prism;
using Prism.Ioc;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace BottlesApp
{
    public partial class App
    {
        private IAuthenticationService _authenticationService;
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            ResolveLocalServices();
            await SetStartPage();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BottlesAppTabbedPage, BottlesAppTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            containerRegistry.RegisterForNavigation<UserPage, UserPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<FavouritePinsPage, FavouritePinsPageViewModel>();
            containerRegistry.RegisterForNavigation<HistoryPage, HistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();

            containerRegistry.RegisterInstance<IRepository>(Container.Resolve<RepositoryService>());
            containerRegistry.RegisterInstance<ISettings>(CrossSettings.Current);
            containerRegistry.RegisterInstance<ISettingsManager>(Container.Resolve<SettingsManager>());
            containerRegistry.RegisterInstance<IAuthenticationService>(Container.Resolve<AuthenticationService>());
            containerRegistry.RegisterInstance<IPinService>(Container.Resolve<PinService>());
            containerRegistry.RegisterInstance<IUserProfileService>(Container.Resolve<UserProfileService>());
        }

        private void ResolveLocalServices()
        {
            _authenticationService = Container.Resolve<IAuthenticationService>();
        }

        private Task SetStartPage()
        {
            var path = $"/{nameof(NavigationPage)}";
            if (_authenticationService.IsAuthorized)
            {
                path += $"/{nameof(BottlesAppTabbedPage)}";
            }
            else
            {
                path += $"/{nameof(LoginPage)}";
            }
            return NavigationService.NavigateAsync(path);
        }
    }
}
