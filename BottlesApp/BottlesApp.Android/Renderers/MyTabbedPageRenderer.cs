
using Android.Content;
using Android.Support.Design.Widget;
using Android.Views;
using BottlesApp.Droid.Renderers;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(MyTabbedPageRenderer))]
namespace BottlesApp.Droid.Renderers
{
    public class MyTabbedPageRenderer : TabbedPageRenderer, TabLayout.IOnTabSelectedListener
    {
        
        private TabbedPage _tabbedPage;
        private BottomNavigationView _bottomNavigationView;

        public MyTabbedPageRenderer(Context context) : base(context)
        {
        }

        #region -- Overrides --

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            var childViews = GetAllChildViews(ViewGroup);

            var scale = Resources.DisplayMetrics.Density;
            var paddingDp = 9;
            var dpAsPixels = (int)(paddingDp * scale + 0.5f);

            foreach (var childView in childViews)
            {
                if (childView is Android.Support.Design.Internal.BottomNavigationItemView tab)
                {
                    tab.SetPadding(tab.PaddingLeft, dpAsPixels, tab.PaddingRight, tab.PaddingBottom);
                }
                else if (childView is Android.Widget.TextView textView)
                {
                    textView.SetTextColor(Android.Graphics.Color.Transparent);
                }
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (_bottomNavigationView != null)
            {
                _bottomNavigationView.ItemIconTintList = null;
            }
        }

        private List<Android.Views.View> GetAllChildViews(Android.Views.View view)
        {
            if (!(view is ViewGroup group))
            {
                return new List<Android.Views.View> { view };
            }

            var result = new List<Android.Views.View>();

            for (int i = 0; i < group.ChildCount; i++)
            {
                var child = group.GetChildAt(i);

                var childList = new List<Android.Views.View> { child };
                childList.AddRange(GetAllChildViews(child));

                result.AddRange(childList);
            }

            return result.Distinct().ToList();
        }

        #endregion

    }
}
