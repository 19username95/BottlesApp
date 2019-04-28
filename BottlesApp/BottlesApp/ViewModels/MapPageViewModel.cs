using BottlesApp.Services;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using System;
using System.Collections.Generic;

namespace BottlesApp.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        IPinService _pinsService;

        public MapPageViewModel(INavigationService navigationService, IPinService pinService)
            : base(navigationService)
        {
            _pinsService = pinService;
        }

        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set { SetProperty(ref _searchString, value); }
        }

        private ObservableCollection<Pin> _pins;
        public ObservableCollection<Pin> Pins
        {
            get { return _pins; }
            set { SetProperty(ref _pins, value); }
        }
        private Pin _foundedPin;
        public Pin FoundedPin
        {
            get { return _foundedPin; }
            set { SetProperty(ref _foundedPin, value); }
        }

        private ICommand _clusterClickedCommand;
        public ICommand ClusterClickedCommand
        {
            get { return _clusterClickedCommand ?? (_clusterClickedCommand = new Command(OnClusterClickedCommand)); }
        }

        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get { return _SearchCommand ?? (_SearchCommand = new Command(OnSearchCommand)); }
        }

        private void OnSearchCommand()
        {
            if (SearchString != null)
            {
                if (SearchString.Equals(string.Empty))
                {
                    FoundedPin = null;
                }
                else
                {
                    FoundedPin = Pins.FirstOrDefault(p => p.Label.ToUpper().Contains(SearchString.ToUpper()));
                }
            }
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);

            GetPinsAsync();
        }
       
        private void OnClusterClickedCommand()
        {

        }

        public async void GetPinsAsync()
        {
            var pins = await _pinsService.GetAllPinsAsync();
            var googlePins = pins.Select(p => p.ToGoogleMapsPin());
            
            Pins = new ObservableCollection<Pin>(googlePins);
        }
    }
}
