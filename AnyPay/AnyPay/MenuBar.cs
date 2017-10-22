using System;

using Android.Content;
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
        private static string NAMESPACE = "http://schemas.android.com/apk/res/org.AnyPay.app";
        private Button BackButton;
        private Button MenuButton;
        public delegate void ClickHandler();
        public event ClickHandler BackHandler;
        public event ClickHandler MenuHandler;

        public MenuBar(Context context) :
            base(context)
        {
            Initialize();
        }

        public MenuBar(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            this.context = context;
            Initialize(attrs);
        }

        public MenuBar(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            this.context = context;
            Initialize(attrs);
        }

        public MenuBar(Context context, IAttributeSet attrs, int defStyle, int defStyleRes) :
            base(context, attrs, defStyle, defStyleRes)
        {
            this.context = context;
            Initialize(attrs);
        }

        public MenuBar(IntPtr handle, JniHandleOwnership owner) :
            base(handle, owner)
        {
            Initialize();
        }

        private void Initialize()
        {
            Inflate(context, Resource.Layout.MenuBar, this);
            SetZ(100.0f);
        }
        private void Initialize(IAttributeSet attrs)
        {
            Initialize();

            BackButton = FindViewById<Button>(Resource.Id.MenuButtonBack);
            if (attrs.GetAttributeBooleanValue(NAMESPACE, "showBack", true))
            {
                BackButton.Visibility = ViewStates.Visible;
                BackButton.Click += delegate
                {
                    BackHandler();
                };
            }
            else
            {
                BackButton.Visibility = ViewStates.Invisible;
            }

            MenuButton = FindViewById<Button>(Resource.Id.MenuButtonMenu);
            if (attrs.GetAttributeBooleanValue(NAMESPACE, "showMenu", true))
            {
                MenuButton.Visibility = ViewStates.Visible;
                MenuButton.Click += delegate
                {
                    MenuHandler();
                };
            }
            else
            {
                MenuButton.Visibility = ViewStates.Invisible;
            }
        }
    }
}