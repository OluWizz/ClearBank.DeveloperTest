using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Tests
{
    [TestClass]
    public class ChapsPaymentSchemeHandlerTests
    {
        [TestMethod]
        public void ValidatePayment_ValidAccount_ReturnsSuccess()
        {
            // Arrange
            var handler = new ChapsPaymentSchemeHandler();
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Live
            };

            // Act
            var result = handler.ValidatePayment(account, 100);

            // Assert
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void ValidatePayment_AccountNotLive_ReturnsFailure()
        {
            // Arrange
            var handler = new ChapsPaymentSchemeHandler();
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Disabled
            };

            // Act
            var result = handler.ValidatePayment(account, 100);

            // Assert
            Assert.IsFalse(result.Success);
        }
    }
}
