using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace BottlesApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSearchBar : ContentView
    {
        public event Action MoveToUserClicked;

        public CustomSearchBar()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MoveToUserClicked?.Invoke();
        }
    }
}