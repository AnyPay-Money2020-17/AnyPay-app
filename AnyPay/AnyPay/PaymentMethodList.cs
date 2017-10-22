using System.Collections.Generic;

namespace AnyPay
{
    class PaymentMethodList
    {
        /* TODO:
         * Implement prepopulated dummy list of payment methods.
         * Then, implement method for loading payment methods from server.
        */

        public List<PaymentMethod> PaymentMethods = new List<PaymentMethod>();

        public PaymentMethodList()
        {
            PaymentMethods.Add(new PaymentMethod("Good", "visa", "XXXX-XXXX-XXXX-9990", "Samp L. Text"));
            PaymentMethods.Add(new PaymentMethod("Cool", "mastercard", "XXXX-XXXX-XXXX-1234", "First N. Last"));
            PaymentMethods.Add(new PaymentMethod("Sweet", "paypal", "pixelfelon@gmail.com", "James Rowley"));
        }
    }
}