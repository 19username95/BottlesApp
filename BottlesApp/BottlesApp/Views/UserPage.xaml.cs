using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace BottlesApp.Views
{
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            int size = 240;
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            Color currColor = Color.FromHex("edefee");

            using (SKPaint paintShader = new SKPaint())
            {
                paintShader.Shader = SKShader.CreateRadialGradient(
                                    new SKPoint(info.Width / 2, info.Height / 2),
                                    size,
                                    new SKColor[] { SKColors.Black, SKColors.Black, SKColors.Gray, currColor.ToSKColor() },
                                    null,
                                    SKShaderTileMode.Repeat);

                canvas.DrawCircle(info.Width / 2, info.Height / 2, size, paintShader);
            }

            currColor = Color.FromHex("d2e8eb");

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = currColor.ToSKColor()
            };
        
            canvas.DrawCircle(info.Width / 2, info.Height / 2 - 20, size - 15, paint);

        }
    }
}
