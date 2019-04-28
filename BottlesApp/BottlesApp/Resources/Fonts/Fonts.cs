using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BottlesApp.Recources.Fonts
{
    public static class Fonts
    {
        public static string CustomFont = Device.OnPlatform(string.Empty, "Fonts/custom_font.otf#custom_font", string.Empty);
    }
}
