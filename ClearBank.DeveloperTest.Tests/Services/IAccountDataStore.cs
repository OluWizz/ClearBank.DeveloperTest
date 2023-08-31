using Moq;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Tests.Mocks
{
    public class MockAccountDataStore : IAccountDataStore
    {
        private readonly Mock<IAccountDataStore> _mock = new Mock<IAccountDataStore>();

        public MockAccountDataStore()
        {
            // Set up any desired behavior for the mock here
            _mock.Setup(ds => ds.GetAccount(It.IsAny<string>())).Returns(new Account
            {
                // Initialize with test data for your tests
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
                // ... other properties
            });
        }

        public Account GetAccount(string accountNumber)
        {
            // Delegate the call to the mock object
            return _mock.Object.GetAccount(accountNumber);
        }

        public void UpdateAccount(Account account)
        {
            // Delegate the call to the mock object
            _mock.Object.UpdateAccount(account);
        }
    }
}
