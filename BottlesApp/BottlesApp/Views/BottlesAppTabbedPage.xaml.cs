using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace BottlesApp.Views
{
    public partial class BottlesAppTabbedPage : Xamarin.Forms.TabbedPage
    {
        public BottlesAppTabbedPage()
        {
            InitializeComponent();
            BarBackgroundColor = Color.FromHex("d2e8eb");
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom)
                .SetBarItemColor(Color.FromHex("179593"));
               // .SetBarSelectedItemColor(Color.FromHex("0f7a78"));

            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            CurrentPage = this.Children.Last();
        }
    }
}
