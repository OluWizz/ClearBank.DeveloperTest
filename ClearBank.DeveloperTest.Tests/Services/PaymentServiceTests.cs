using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Data;

namespace ClearBank.DeveloperTest.Tests
{
    [TestClass]
    public class PaymentServiceTests
    {
        [TestMethod]
        public void MakePayment_WithValidBacsPayment_ReturnsSuccess()
        {
            // Arrange
            var accountDataStoreMock = new Mock<IAccountDataStore>();
            accountDataStoreMock.Setup(ds => ds.GetAccount(It.IsAny<string>())).Returns(new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            });

            var paymentSchemeHandlerFactoryMock = new Mock<IPaymentSchemeHandlerFactory>();
            paymentSchemeHandlerFactoryMock.Setup(f => f.CreateHandler(PaymentScheme.Bacs))
                                           .Returns(new BacsPaymentSchemeHandler());

            var paymentService = new PaymentService(accountDataStoreMock.Object, paymentSchemeHandlerFactoryMock.Object);

            var request = new MakePaymentRequest
            {
                PaymentScheme = PaymentScheme.Bacs,
                DebtorAccountNumber = "672",
                Amount = 100
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.IsTrue(result.Success);
        }
    }
}
