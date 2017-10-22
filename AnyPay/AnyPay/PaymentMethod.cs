namespace AnyPay
{
    class PaymentMethod
    {
        /* TODO:
         * Implement class containing all critical information for executing a payment.
         * Implement method to request encrypted card data from server for executing payment.
        */

        public string ShortName { get; private set; }
        public string PaymentMethodType { get; private set; }

        public PaymentMethod(string sn, string pmt)
        {
            ShortName = sn;
            PaymentMethodType = pmt;
        }
    }
}