namespace AnyPay
{
    public class PaymentMethod
    {
        /* TODO:
         * Implement class containing all critical information for executing a payment.
         * Implement method to request encrypted card data from server for executing payment.
        */

        public string ShortName { get; private set; }
        public string PaymentMethodType { get; private set; }
        public string ObfuscatedAccountNumber { get; private set; }
        public string AccountHolder { get; private set; }
        public string UID { get; private set; }

        public PaymentMethod(string sn, string pmt, string oan, string ah, string uid)
        {
            ShortName = sn;
            PaymentMethodType = pmt;
            ObfuscatedAccountNumber = oan;
            AccountHolder = ah;
            UID = uid;
        }
    }
}