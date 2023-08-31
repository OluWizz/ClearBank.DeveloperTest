using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentSchemeHandlerFactory
    {
        IPaymentSchemeHandler CreateHandler(PaymentScheme paymentScheme);
    }
}
