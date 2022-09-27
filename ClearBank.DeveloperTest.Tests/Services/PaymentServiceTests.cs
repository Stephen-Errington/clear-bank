using System;
using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Interfaces.Factories;
using ClearBank.DeveloperTest.Interfaces.Services;
using ClearBank.DeveloperTest.Interfaces.Validators;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClearBank.DeveloperTest.Tests.Factories
{
    [TestClass]
    public class PaymentServiceTests
    {
        private Mock<IAccountService> _accountService;
        private Mock<IPaymentValidatorFactory> _paymentValidatorFactory;
        private Mock<IPaymentValidator> _paymentValidator;
        private PaymentService _paymentService;

        [TestInitialize]
        public void TestInitialise()
        {
            _accountService = new Mock<IAccountService>();
            _paymentValidatorFactory = new Mock<IPaymentValidatorFactory>();
            _paymentValidator = new Mock<IPaymentValidator>();
            _paymentService = new PaymentService(_accountService.Object, _paymentValidatorFactory.Object);
        }

        [TestMethod]
        public void NoAccountFound_ShouldReturnFalse()
        {
            _accountService.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(null as Account);
            _paymentValidator.Setup(x => x.IsValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>())).Verifiable();
            _paymentValidatorFactory.Setup(x => x.GetInstance(It.IsAny<PaymentScheme>())).Returns(_paymentValidator.Object);

            var request = new MakePaymentRequest();
            var actual = _paymentService.MakePayment(request);

            Assert.AreEqual(false, actual.Success);
            _paymentValidatorFactory.Verify(x => x.GetInstance(It.IsAny<PaymentScheme>()), Times.Never);
            _paymentValidator.Verify(x => x.IsValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()), Times.Never);
            
        }

        [TestMethod]
        public void IsValid_ShouldReturnTrue()
        {
            _accountService.Setup(x => x.GetAccount(It.IsAny<string>())).Returns(new Account());
            _paymentValidator.Setup(x => x.IsValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>())).Returns(true);
            _paymentValidatorFactory.Setup(x => x.GetInstance(It.IsAny<PaymentScheme>())).Returns(_paymentValidator.Object);

            var request = new MakePaymentRequest();
            var actual = _paymentService.MakePayment(request);

            Assert.AreEqual(true, actual.Success);
            _paymentValidatorFactory.Verify(x => x.GetInstance(request.PaymentScheme), Times.Once);
            _paymentValidator.Verify(x => x.IsValid(It.IsAny<MakePaymentRequest>(), It.IsAny<Account>()), Times.Once);
        }
    }
}
