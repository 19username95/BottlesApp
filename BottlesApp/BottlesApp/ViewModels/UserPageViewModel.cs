using BottlesApp.Services;
using BottlesApp.Views;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace BottlesApp.ViewModels
{
    public class UserPageViewModel : ViewModelBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IAuthenticationService _authenticationService;

        public UserPageViewModel(INavigationService navigationService, ISettingsManager settingsManager, IAuthenticationService authenticationService, IUserProfileService userProfileService)
            : base(navigationService)
        {
            _userProfileService = userProfileService;
            _authenticationService = authenticationService;
        }

        private int _savedBottles;
        public int SavedBottles
        {
            get => _savedBottles;
            set => SetProperty(ref _savedBottles, value);
        }

        private string _savedCarbone;
        public string SavedCarbone
        {
            get => _savedCarbone;
            set => SetProperty(ref _savedCarbone, value);
        }


        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            var user = await _userProfileService.GetCurrentUserAsync();
            Title = user?.Name;
            SavedBottles = user.BottlesSaved;
            SavedCarbone = System.Convert.ToString(user.CarboneSaved) + " g";
        }

        private ICommand _favouritePinsCommand;
        public ICommand FavouritePinsCommand
        {
            get { return _favouritePinsCommand ?? (_favouritePinsCommand = new Command(OnFavouritePinsCommand)); }
        }
        private async void OnFavouritePinsCommand()
        {
            await NavigationService.NavigateAsync($"/{nameof(FavouritePinsPage)}");
        }

        private ICommand _historyCommand;
        public ICommand HistoryCommand
        {
            get { return _historyCommand ?? (_historyCommand = new Command(OnHistoryCommand)); }
        }
        private async void OnHistoryCommand()
        {
            await NavigationService.NavigateAsync($"/{nameof(HistoryPage)}");
        }

        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get { return _settingsCommand ?? (_settingsCommand = new Command(OnSettingsCommand)); }
        }
        private async void OnSettingsCommand()
        {
            await NavigationService.NavigateAsync($"/{nameof(SettingsPage)}");
        }

        private ICommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get { return _logoutCommand ?? (_logoutCommand = new Command(OnLogout)); }
        }

        private async void OnLogout()
        {
            _authenticationService.Logout();

            await NavigationService.GoBackToRootAsync();
            await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(LoginPage)}");
        }

    }
}
