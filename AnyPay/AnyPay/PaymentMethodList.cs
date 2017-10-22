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
            PaymentMethods.Add(new PaymentMethod("Good"));
            PaymentMethods.Add(new PaymentMethod("Cool"));
            PaymentMethods.Add(new PaymentMethod("Neat"));
            PaymentMethods.Add(new PaymentMethod("Fun"));
            PaymentMethods.Add(new PaymentMethod("Sweet"));
        }
    }
}