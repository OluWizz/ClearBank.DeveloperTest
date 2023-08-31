using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class ChapsPaymentSchemeHandler : IPaymentSchemeHandler
    {
        public MakePaymentResult ValidatePayment(Account account, decimal amount)
        {
            var result = new MakePaymentResult();

            // CHAPS payment scheme validation
            if (account == null)
            {
                result.Success = false;
                result.ErrorMessage = "Account not found.";
            }
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
            {
                result.Success = false;
                result.ErrorMessage = "CHAPS payments is not allowed.";
            }
            else if (account.Status != AccountStatus.Live)
            {
                result.Success = false;
                result.ErrorMessage = "This is not a live account.";
            }
            else
            {
                result.Success = true;
            }

            return result;
        }
    }
}
