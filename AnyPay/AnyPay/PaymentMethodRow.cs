using System;
using System.Collections.Generic;

using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using Android.Graphics;

namespace AnyPay
{
    [Register("org.AnyPay.app.AnyPay.AnyPay.PaymentMethodRow")]
    class PaymentMethodRow : LinearLayout
    {
        private Context context;
        private RelativeLayout CardContainer;
        private ImageView CardImage;
        private TextView CardShortName;
        private TextView CardHolderName;
        private TextView CardAccountNumber;
        private BitmapCache bitmapCache;

        public PaymentMethodRow(Context context, BitmapCache bitmapCache) : base(context)
        {
            this.context = context;
            this.bitmapCache = bitmapCache;
            InitializeView();
        }
        
        public PaymentMethodRow(Context context) :
            base(context)
        {
            InitializeView();
        }

        public PaymentMethodRow(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            this.context = context;
            InitializeView();
        }

        public PaymentMethodRow(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            this.context = context;
            InitializeView();
        }

        public PaymentMethodRow(Context context, IAttributeSet attrs, int defStyle, int defStyleRes) :
            base(context, attrs, defStyle, defStyleRes)
        {
            this.context = context;
            InitializeView();
        }

        public PaymentMethodRow(IntPtr handle, JniHandleOwnership owner) :
            base(handle, owner)
        {
            InitializeView();
        }


        private void InitializeView()
        {
            Inflate(context, Resource.Layout.PaymentMethodRow, this);
            CardContainer = FindViewById<RelativeLayout>(Resource.Id.CardContainer);
            CardImage = FindViewById<ImageView>(Resource.Id.CardImage);
            CardShortName = FindViewById<TextView>(Resource.Id.CardShortName);
            CardHolderName = FindViewById<TextView>(Resource.Id.CardHolderName);
            CardAccountNumber = FindViewById<TextView>(Resource.Id.CardAccountNumber);
            CardContainer.ClipToOutline = true;
        }

        public void UpdateViewData(PaymentMethod data)
        {
            CardShortName.Text = data.ShortName;
            CardHolderName.Text = data.AccountHolder;
            CardAccountNumber.Text = data.ObfuscatedAccountNumber;
            CardGraphicDefinition imageResource = GetCardGraphicsByName(data.PaymentMethodType);
            if (bitmapCache != null)
                CardImage.SetImageBitmap(bitmapCache.GetBitmap(imageResource.GraphicResource));
            else
                CardImage.SetImageResource(imageResource.GraphicResource);
            Color textColor = Color.ParseColor(imageResource.TextColor);
            CardShortName.SetTextColor(textColor);
            CardHolderName.SetTextColor(textColor);
            CardAccountNumber.SetTextColor(textColor);
        }

        private class CardGraphicDefinition
        {
            public int GraphicResource;
            public string TextColor;
            /* could also hold position of texts etc */
        }
        private static IDictionary<string, CardGraphicDefinition> cardImages = new Dictionary<string, CardGraphicDefinition> {
            {"visa", new CardGraphicDefinition {
                GraphicResource = Resource.Drawable.visa_base_xxhdpi,
                TextColor = "#ff222222"
            }},
            {"mastercard", new CardGraphicDefinition {
                GraphicResource = Resource.Drawable.mastercard_base_xxhdpi,
                TextColor = "#ffeeeeee"
            }}
        };
        private static CardGraphicDefinition[] defaultCardImages = new CardGraphicDefinition[]
        {
            new CardGraphicDefinition {
                GraphicResource = Resource.Drawable.acf_ncc_red_xxhdpi,
                TextColor = "#ff000000"
            },
            new CardGraphicDefinition {
                GraphicResource = Resource.Drawable.acf_ncc_green_xxhdpi,
                TextColor = "#ff000000"
            },
            new CardGraphicDefinition {
                GraphicResource = Resource.Drawable.acf_ncc_blue_xxhdpi,
                TextColor = "#ff000000"
            }
        };
        private CardGraphicDefinition GetCardGraphicsByName(string name)
        {
            CardGraphicDefinition resource;
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