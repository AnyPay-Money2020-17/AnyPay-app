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
            PaymentMethods.Add(new PaymentMethod("Good", "mastercard"));
            PaymentMethods.Add(new PaymentMethod("Cool", "visa"));
            PaymentMethods.Add(new PaymentMethod("Neat", "paypal"));
            PaymentMethods.Add(new PaymentMethod("Fun", "visa_target"));
            PaymentMethods.Add(new PaymentMethod("Sweet", "gc_target"));
        }
    }
}