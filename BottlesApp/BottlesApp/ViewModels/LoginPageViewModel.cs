using BottlesApp.Extensions;
using BottlesApp.Services;
using BottlesApp.Views;
using Prism.Navigation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Input;
using Xamarin.Forms;

namespace BottlesApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private IAuthenticationService _authenticationService { get; }
        private ISettingsManager _settingsManager { get; }

        public LoginPageViewModel(INavigationService navigationService, IAuthenticationService authenticationService, ISettingsManager settingsManager)
            : base(navigationService)
        {
            _authenticationService = authenticationService;
            _settingsManager = settingsManager;
            Title = "SIGN IN";
        }

        private bool _isLoginInvalid;
        public bool IsLoginInvalid
        {
            get { return _isLoginInvalid; }
            set { SetProperty(ref _isLoginInvalid, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new Command(OnLoginCommand)); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if(propertyName == nameof(Password)|| propertyName == nameof(Username))
            {
                IsLoginInvalid = false;
            }
        }

        private async void OnLoginCommand(object hash)
        {
            var hashedPassword = GetMd5HashedPassword(Password);
            await _authenticationService.LoginAsync(Username, hashedPassword);

            if (_settingsManager.IsAuthorized)
            {
                await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(BottlesAppTabbedPage)}");
            }
            else
            {
                IsLoginInvalid = true;
            }
        }

        private string GetMd5HashedPassword(string password)
        {
            if (password != null)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    return md5Hash.GetMd5Hash(password);
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
