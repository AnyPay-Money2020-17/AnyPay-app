using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using Android.Util;

using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace AnyPay
{
    [Activity(Label = "AnyPay Payment")]
    class Pay : Activity
    {
        /* TODO:
         * Implement user interface for executing a payment with the selected method.
         * Later, implement method for managing payment method.
        */

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Pay);

            PaymentMethod CurrentMethod;
            if (Intent.HasExtra("PM_UID") && CurrentAccount.account != null)
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

            string PaymentData = await RequestPaymentInformation(CurrentMethod, CurrentAccount.account);
            if (PaymentData.Length < 1)
            {
                Finish();
                return;
            }

            Log.Info("anypay-api", PaymentData);

            PaymentMethodRow PMView = FindViewById<PaymentMethodRow>(Resource.Id.CurrentCard);
            PMView.UpdateViewData(CurrentMethod);

            RelativeLayout loadingPanel = FindViewById<RelativeLayout>(Resource.Id.loadingPanel);
            loadingPanel.Visibility = ViewStates.Gone;

            MenuBar menuBar = FindViewById<MenuBar>(Resource.Id.MenuBar);
            menuBar.BackHandler += delegate
            {
                Finish();
            };

            ExpirationTimer timer = new ExpirationTimer(30000, 1000, this);
            timer.Start();
        }

        private class ExpirationTimer : CountDownTimer
        {
            private Pay parent;

            public ExpirationTimer(long totaltime, long interval, Pay parent) : base(totaltime, interval)
            {
            this.parent = parent;
            }

            public override void OnTick(long millisUntilFinished)
            {
                parent.UpdateTime(millisUntilFinished);
            }

            public override void OnFinish()
            {
            parent.TimerDone();
            }
        }
        
        protected void UpdateTime(long millisTil)
        {

        }
        protected void TimerDone()
        {
            FindViewById<TextView>(Resource.Id.TitleText).Visibility = ViewStates.Invisible;
            FindViewById<TextView>(Resource.Id.FlavorText).Text = "The payment period has expired.";
        }


        private static string ENDPOINT = "https://5nyjla88ub.execute-api.us-west-1.amazonaws.com/prod/AnyPay-Pay";

        private async Task<string> RequestPaymentInformation(PaymentMethod method, Account account)
        {
            WebRequest webRequest = WebRequest.Create(ENDPOINT);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/base64";
            webRequest.Headers.Add("user_id", account.UID);
            webRequest.Headers.Add("payment_id", method.UID);

            if (webRequest == null)
            {
                return "";
            }

            WebResponse webResponse = await webRequest.GetResponseAsync().ConfigureAwait(false);
            if (webResponse == null)
            {
                return "";
            }

            Stream streamResponse = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(streamResponse);
            string base64 = reader.ReadToEnd();

            reader.Close();
            streamResponse.Close();
            webResponse.Close();

            return base64;
        }
    }
}