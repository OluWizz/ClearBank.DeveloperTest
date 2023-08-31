using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class BacsPaymentSchemeHandler : IPaymentSchemeHandler
    {
        public MakePaymentResult ValidatePayment(Account account, decimal amount)
        {
            var result = new MakePaymentResult();

            // Bacs payment scheme validation logic
            if (account == null)
            {
                result.Success = false;
                result.ErrorMessage = "No account found.";
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
            {
                result.Success = false;
                result.ErrorMessage = "Bacs payments is not allowed.";
            }
            else
            {
                result.Success = true;
            }

            return result;
        }
    }
}
