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
            SetContentView(Resource.Layout.Main);

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

        public PaymentMethodListAdapter(Activity context, PaymentMethodList documents) : base()
        {
            this.context = context;
            this.methods = documents;
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
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

            TextView textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);

            textView.Text = methods.PaymentMethods[position].ShortName;

            return view;
        }
    }
}

