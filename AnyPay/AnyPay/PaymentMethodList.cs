using System.Collections.Generic;

namespace AnyPay
{
    public class PaymentMethodList
    {
        /* TODO:
         * Implement prepopulated dummy list of payment methods.
         * Then, implement method for loading payment methods from server.
        */

        public List<PaymentMethod> PaymentMethods = new List<PaymentMethod>();

        public PaymentMethodList()
        {
            PaymentMethods.Add(new PaymentMethod("", "visa", "XXXX-XXXX-XXXX-9990", "Samp L. Text", "8acb83b6-8c30-4f26-9a08-cc11980a9b7c"));
            PaymentMethods.Add(new PaymentMethod("", "mastercard", "XXXX-XXXX-XXXX-1234", "First N. Last", "1"));
            PaymentMethods.Add(new PaymentMethod("My Paypal", "paypal", "pixelfelon@gmail.com", "James Rowley", "2"));
        }

        public PaymentMethod GetPaymentMethodByUID(string UID)
        {
            return PaymentMethods.Find(x => x.UID == UID);
        }
    }
}