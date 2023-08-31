using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentSchemeHandler
    {
        MakePaymentResult ValidatePayment(Account account, decimal amount);
    }
}
