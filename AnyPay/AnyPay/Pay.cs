using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;

namespace AnyPay
{
    [Activity(Label = "AnyPay Payment")]
    class Pay : Activity
    {
        /* TODO:
         * Implement user interface for executing a payment with the selected method.
         * Later, implement method for managing payment method.
        */

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Pay);

            PaymentMethod CurrentMethod;
            if (Intent.HasExtra("PM_UID"))
            {
                string PM_UID = Intent.GetStringExtra("PM_UID");
                try
                {
                    CurrentMethod = CurrentAccount.account.PaymentMethods.GetPaymentMethodByUID(PM_UID);
                }
                catch
                {
                    Finish();
                    return;
                }
            }
            else
            {
                Finish();
                return;
            }

            PaymentMethodRow PMView = FindViewById<PaymentMethodRow>(Resource.Id.CurrentCard);
            PMView.UpdateViewData(CurrentMethod);

            MenuBar menuBar = FindViewById<MenuBar>(Resource.Id.MenuBar);
            menuBar.BackHandler += delegate
            {
                Finish();
            };
        }
    }
}