using BottlesApp.ViewModels;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.GoogleMaps.Clustering;

namespace BottlesApp.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var x = (MapPageViewModel)BindingContext;
            x.GetPinsAsync();
            map.Pins.Clear();
            foreach (Pin p in x.Pins)
            {
                map.Pins.Add(p);
            }
           // map.ClusterOptions = new ClusterOptions() { BucketColors = Color.SeaGreen };
            await map.MoveToUserPositionAsync();
        }

        private void CustomSearchBar_MoveToUserClicked()
        {
            map.MoveToUser();
        }
    }
}
