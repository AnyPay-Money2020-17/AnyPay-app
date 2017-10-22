using System.Collections.Generic;

using Android.Content;
using Android.Graphics;
using Android.Util;

namespace AnyPay
{
    public class BitmapCache
    {
        private Context context;
        private Dictionary<int, Bitmap> bitmapCache = new Dictionary<int, Bitmap>();
        private BitmapFactory.Options bitmapOptions;

        public BitmapCache(Context context, int sourceDPI)
        {
            this.context = context;
            bitmapOptions = new BitmapFactory.Options();
            bitmapOptions.InDensity = sourceDPI;
            bitmapOptions.InTargetDensity = (int)this.context.Resources.DisplayMetrics.DensityDpi;
            bitmapOptions.InScaled = true;
        }

        public Bitmap GetBitmap(int resourceID)
        {
            Bitmap result;
            if (!bitmapCache.TryGetValue(resourceID, out result))
            {
                result = BitmapFactory.DecodeResource(context.Resources, resourceID, bitmapOptions);
                bitmapCache.Add(resourceID, result);
            }
            return result;
        }
    }
}