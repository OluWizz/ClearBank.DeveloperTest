using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Services;

namespace ClearBank.DeveloperTest.Tests
{
    [TestClass]
    public class BacsPaymentSchemeHandlerTests
    {
        [TestMethod]
        public void ValidatePayment_ValidAccount_ReturnsSuccess()
        {
            // Arrange
            var handler = new BacsPaymentSchemeHandler();
            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };

            // Act
            var result = handler.ValidatePayment(account, 100);

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}
