using Android.App;
using Android.OS;

namespace AnyPay
{
    [Activity(Label = "AppPay Account")]
    class AccountView : Activity
    {
        /* TODO:
         * Implement the user interface for viewing account details.
        */

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Account);

            MenuBar menuBar = FindViewById<MenuBar>(Resource.Id.MenuBar);
            menuBar.BackHandler += delegate
            {
                Finish();
            };
        }
    }
}