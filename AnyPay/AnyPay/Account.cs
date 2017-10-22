using System;
namespace AnyPay
{
    public class CurrentAccount
    {
        public static Account account;
    }

    public class Account
    {
        /* TODO:
         * Implement a class containing all data representing a user account.
         * Implement a method to connect to the server and allow communication.
         * Implement a method to restore communication to the server from a token.
         * Implement a method to add a new payment method to an account.
        */

        public string UID { get; private set; }
        public PaymentMethodList PaymentMethods { get; private set; }
        
        public Account()
        {
            //Static testing UID
            UID = "7399a968-a4df-4daf-acb6-70603433ca94";
            PaymentMethods = new PaymentMethodList();
        }
    }
}