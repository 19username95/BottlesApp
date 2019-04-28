using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Prism;
using Prism.Ioc;
using System;

namespace BottlesApp.Droid
{
    [Activity(Label = "BottlesApp", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            ebaniyrot:
            
           


            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsGoogleMaps.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
            // hide status bar
            Window.AddFlags(WindowManagerFlags.Fullscreen);


        }

        protected override void OnStart()
        {
            base.OnStart();
            const string permission = Manifest.Permission.AccessFineLocation;
            while (ContextCompat.CheckSelfPermission(this, permission) != Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessCoarseLocation, Manifest.Permission.AccessFineLocation }, 0);
            }
        }
    }
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

