using Android.App;
using Android.Widget;
using Android.OS;

namespace AnyPay
{
    [Activity(Label = "AnyPay", MainLauncher = true, Icon = "@drawable/icon")]
    public class PaymentMethodListView : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            /* TODO:
             * Implement displayed list of payment methods associated with the user.
             * Respond to tapping on a payment method by opening the payment view.
             * Add options button or panel to open views for setting up account and adding payment methods.
            */
        }
    }
}

