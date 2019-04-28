using Plugin.Geolocator;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Clustering;

namespace BottlesApp.Controls
{
    public class CustomClusteringMap : ClusteredMap
    {
        public CustomClusteringMap() : base()
        {
            ClusterClicked += CustomClusteringMap_ClusterClicked;
            PinClicked += CustomClusteringMap_PinClicked;
            MyLocationEnabled = true;
            //Cluster();
        }

        private void CustomClusteringMap_PinClicked(object sender, PinClickedEventArgs e)
        {
            PinClickedCommand?.Execute(BindingContext);
        }

        private void CustomClusteringMap_ClusterClicked(object sender, ClusterClickedEventArgs e)
        {
            ClusterClickedCommand?.Execute(BindingContext);
        }

        public static readonly BindableProperty PinsSourceProperty = BindableProperty.Create(nameof(PinsSource), typeof(ObservableCollection<Pin>), typeof(CustomClusteringMap), null);
        public ObservableCollection<Pin> PinsSource
        {
            get { return (ObservableCollection<Pin>)GetValue(PinsSourceProperty); }
            set { SetValue(PinsSourceProperty, value); }
        }

        public static readonly BindableProperty FoundedPinProperty = BindableProperty.Create(nameof(FoundedPin), typeof(Pin), typeof(CustomClusteringMap), null);
        public Pin FoundedPin
        {
            get { return (Pin)GetValue(FoundedPinProperty); }
            set { SetValue(FoundedPinProperty, value); }
        }

        public static readonly BindableProperty ClusterClickedCommandProperty = BindableProperty.Create(nameof(ClusterClickedCommand), typeof(ICommand), typeof(CustomClusteringMap), null);
        public ICommand ClusterClickedCommand
        {
            get { return (ICommand)GetValue(ClusterClickedCommandProperty); }
            set { SetValue(ClusterClickedCommandProperty, value); }
        }

        public static readonly BindableProperty PinClickedCommandProperty = BindableProperty.Create(nameof(PinClickedCommand), typeof(ICommand), typeof(CustomClusteringMap), null);
        public ICommand PinClickedCommand
        {
            get { return (ICommand)GetValue(PinClickedCommandProperty); }
            set { SetValue(PinClickedCommandProperty, value); }
        }
        
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (PinsSourceProperty.PropertyName == propertyName)
            {
                Pins.Clear();
                foreach (var pin in PinsSource)
                {
                    Pins.Add(pin);
                }
                Cluster();
            }

            if (FoundedPinProperty.PropertyName == propertyName)
            {
                MoveToFoundedPin();
            }
            

        }

        private async void  MoveToFoundedPin()
        {
            if(FoundedPin == null)
            {
                await MoveToUserPositionAsync();
            }
            else
            {
                MoveToRegion(MapSpan.FromCenterAndRadius(new Position(FoundedPin.Position.Latitude, FoundedPin.Position.Longitude),
                                                         Distance.FromMeters(800)));
            }
        }
        public async void MoveToUser()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                                         Distance.FromMeters(800)));
        }
        public async Task MoveToUserPositionAsync()
        {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude),
                                                         Distance.FromMeters(1100000)));
        }
    }
}