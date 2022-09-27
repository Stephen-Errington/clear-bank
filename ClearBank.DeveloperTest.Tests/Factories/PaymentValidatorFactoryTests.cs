using System;
using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Interfaces.Validators;
using ClearBank.DeveloperTest.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Factories
{
    [TestClass]
    public class PaymentValidatorFactoryTests
    {
        private PaymentValidatorFactory _paymentValidatorFactory;

        [TestInitialize]
        public void TestInitialise()
        {
            var paymentValidators = new IPaymentValidator[]
            {
                new FasterPaymentsValidator(),
                new BacsValidator()
            };

            _paymentValidatorFactory = new PaymentValidatorFactory(paymentValidators);
        }

        [TestMethod]
        public void ReturnsRequestedInstance()
        {
            var paymentScheme = PaymentScheme.FasterPayments;

            var paymentValidator = _paymentValidatorFactory.GetInstance(paymentScheme);

            Assert.AreEqual(paymentValidator.PaymentScheme, paymentScheme);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowsErrorIfNotFound()
        {
            var paymentScheme = PaymentScheme.Chaps;

            var paymentValidator = _paymentValidatorFactory.GetInstance(paymentScheme);

            Assert.AreEqual(paymentValidator.PaymentScheme, paymentScheme);
        }
    }
}
