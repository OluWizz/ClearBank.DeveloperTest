using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class FasterPaymentsSchemeHandler : IPaymentSchemeHandler
    {
        public MakePaymentResult ValidatePayment(Account account, decimal amount)
        {
            var result = new MakePaymentResult();

            // Faster Payments payment scheme validation logic
            if (account == null)
            {
                result.Success = false;
                result.ErrorMessage = "No Account found.";
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
            {
                result.Success = false;
                result.ErrorMessage = "Faster Payments is not allowed.";
            }
            else if (account.Balance < amount)
            {
                result.Success = false;
                result.ErrorMessage = "Insufficient balance available.";
            }
            else
            {
                result.Success = true;
            }

            return result;
        }
    }
}
