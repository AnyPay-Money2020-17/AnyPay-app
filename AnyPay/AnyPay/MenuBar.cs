using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;


namespace AnyPay
{
    [Register("org.AnyPay.app.AnyPay.AnyPay.MenuBar")]
    public class MenuBar : LinearLayout
    {
        private Context context;

        public MenuBar(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            this.context = context;
            Initialize();
        }

        public MenuBar(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            this.context = context;
            Initialize();
        }

        private void Initialize()
        {
            Inflate(context, Resource.Layout.MenuBar, this);
        }
    }
}