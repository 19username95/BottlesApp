using BottlesApp.Views;
using SQLite;
using Xamarin.Forms.GoogleMaps;

namespace BottlesApp.Models
{
    public class PinModel : IEntityBase
    {
        [PrimaryKey]
        public int Id { get; set; }
        //[ManyToOne]
        //[ForeignKey(typeof(UserProfileModel), Name="Id")]
        //public UserProfileModel User { get; set; }
        public double Lng { get; set; }
        public double Ltd { get; set; }
        public string Label { get; set; }

        public Pin ToGoogleMapsPin()
        {
            return new Pin
            {
                Label = this.Label,
                Position = new Position(Ltd, Lng),
                Icon = BitmapDescriptorFactory.FromView(new BindingPinView())
            };
        }
    }
}
