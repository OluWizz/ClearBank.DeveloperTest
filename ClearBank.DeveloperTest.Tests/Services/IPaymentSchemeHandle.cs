using ClearBank.DeveloperTest.Types;
using System.ComponentModel.DataAnnotations;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentSchemeHandler
    {
        PaymentScheme PaymentScheme { get; }
        ValidationResult ValidatePayment(Account account, decimal amount);
    }
}
