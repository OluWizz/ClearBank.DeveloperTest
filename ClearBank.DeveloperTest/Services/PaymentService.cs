using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStore _dataStore;
        private readonly IPaymentSchemeHandlerFactory _paymentSchemeHandlerFactory;

        public PaymentService(IAccountDataStore dataStore, IPaymentSchemeHandlerFactory paymentSchemeHandlerFactory)
        {
            _dataStore = dataStore;
            _paymentSchemeHandlerFactory = paymentSchemeHandlerFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = _dataStore.GetAccount(request.DebtorAccountNumber);

            var paymentSchemeHandler = _paymentSchemeHandlerFactory.CreateHandler(request.PaymentScheme);
            var result = paymentSchemeHandler.ValidatePayment(account, request.Amount);

            if (result.Success)
            {
                account.Balance -= request.Amount;
                _dataStore.UpdateAccount(account);
            }

            return result;
        }
    }
}
