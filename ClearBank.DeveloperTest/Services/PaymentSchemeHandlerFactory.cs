using System;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public static class PaymentSchemeHandlerFactory
    {
        public static IPaymentSchemeHandler CreateHandler(PaymentScheme paymentScheme)
        {
            switch (paymentScheme)
            {
                case PaymentScheme.Bacs:
                    return new BacsPaymentSchemeHandler();
                case PaymentScheme.FasterPayments:
                    return new FasterPaymentsSchemeHandler();
                case PaymentScheme.Chaps:
                    return new ChapsPaymentSchemeHandler();
                default:
                    throw new ArgumentException("Invalid payment scheme.", nameof(paymentScheme));
            }
        }
    }
}
