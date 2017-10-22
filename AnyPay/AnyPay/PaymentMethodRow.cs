using System.Collections.Generic;

using Android.Content;
using Android.Widget;

namespace AnyPay
{
    class PaymentMethodRow : LinearLayout
    {
        private Context context;
        private RelativeLayout CardContainer;
        private ImageView CardImage;
        private TextView CardShortName;
        private BitmapCache bitmapCache;

        public PaymentMethodRow(Context context, BitmapCache bitmapCache) : base(context)
        {
            this.context = context;
            this.bitmapCache = bitmapCache;
            InitializeView();
        }


        private void InitializeView()
        {
            Inflate(context, Resource.Layout.PaymentMethodRow, this);
            CardContainer = FindViewById<RelativeLayout>(Resource.Id.CardContainer);
            CardImage = FindViewById<ImageView>(Resource.Id.CardImage);
            CardShortName = FindViewById<TextView>(Resource.Id.CardShortName);
            CardContainer.ClipToOutline = true;
        }

        public void UpdateViewData(PaymentMethod data)
        {
            CardShortName.Text = data.ShortName;
            int imageResource = GetCardImageResourceByName(data.PaymentMethodType);
            CardImage.SetImageBitmap(bitmapCache.GetBitmap(imageResource));
        }


        private static IDictionary<string, int> cardImages = new Dictionary<string, int> {
            {"mastercard", Resource.Drawable.acf_nc_red_xxhdpi} //you get the idea
        };
        private static int[] defaultCardImages = new int[]
        {
            Resource.Drawable.acf_nc_red_xxhdpi,
            Resource.Drawable.acf_nc_green_xxhdpi,
            Resource.Drawable.acf_nc_blue_xxhdpi
        };
        protected int GetCardImageResourceByName(string name)
        {
            int resource = 0;
            if (!cardImages.TryGetValue(name, out resource))
            {
                int idx_max = defaultCardImages.Length - 1;
                int idx = name.GetHashCode() % idx_max;
                if (idx < 0) idx += idx_max;
                resource = defaultCardImages[idx];
            }
            return resource;
        }
    }
}