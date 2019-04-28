using BottlesApp.Views;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace BottlesApp.ViewModels
{
    public class FavouritePinsPageViewModel : ViewModelBase
    {
        public FavouritePinsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get { return _backCommand ?? (_backCommand = new Command(OnBackCommand)); }
        }
        private async void OnBackCommand()
        {
            await NavigationService.NavigateAsync($"/{nameof(BottlesAppTabbedPage)}");
        }
    }
}
