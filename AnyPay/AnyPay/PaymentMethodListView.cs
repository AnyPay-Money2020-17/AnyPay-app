using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace AnyPay
{
    [Activity(Label = "AnyPay", MainLauncher = true)]
    public class PaymentMethodListView : Activity
    {
        private PaymentMethodListAdapter PMListAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.PaymentMethodList);

            MenuBar menuBar = FindViewById<MenuBar>(Resource.Id.MenuBar);
            menuBar.MenuHandler += delegate
            {
                StartActivity(typeof(AccountView));
            };

            ListView PMListView = FindViewById<ListView>(Resource.Id.PMList);
            PMListAdapter = new PaymentMethodListAdapter(this, new PaymentMethodList());
            PMListView.Adapter = PMListAdapter;
            PMListAdapter.NotifyDataSetChanged();

            /* TODO:
             * Implement displayed list of payment methods associated with the user.
             * Respond to tapping on a payment method by opening the payment view.
             * Add options button or panel to open views for setting up account and adding payment methods.
            */
        }
    }

    class PaymentMethodListAdapter : BaseAdapter<PaymentMethod>
    {
        private PaymentMethodList methods;
        private Activity context;
        private BitmapCache bitmapCache;

        public PaymentMethodListAdapter(Activity context, PaymentMethodList documents) : base()
        {
            this.context = context;
            this.methods = documents;
            bitmapCache = new BitmapCache(this.context, 540);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override PaymentMethod this[int position]
        {
            get { return methods.PaymentMethods[position]; }
        }

        public override int Count
        {
            get { return methods.PaymentMethods.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            PaymentMethodRow view = (PaymentMethodRow) convertView;
            if (view == null)
                view = new PaymentMethodRow(context, bitmapCache);

            view.UpdateViewData(methods.PaymentMethods[position]);
            return view;
        }
    }
}

