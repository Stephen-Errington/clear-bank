using System;
using System.Collections.Generic;
using System.Linq;
using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Interfaces.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    [TestClass]
    public class PaymentSchemeValidatorTests
    {
        [TestMethod]
        public void EachPaymentScheme_ShouldHaveAValidator()
        {
            var allPaymentSchemes = Enum.GetValues(typeof(PaymentScheme)).Cast<PaymentScheme>();

            var paymentValidatorType = typeof(IPaymentValidator);
            var paymentValidators = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.GetConstructor(Type.EmptyTypes) != null &&
                    paymentValidatorType.IsAssignableFrom(p) &&
                    p.IsClass && !p.IsAbstract && !p.IsInterface);

            var paymentSchemeValidatorCreated = new List<PaymentScheme>();

            foreach (var paymentValidator in paymentValidators)
            {
                var paymentValidatorInstance = (IPaymentValidator)Activator.CreateInstance(paymentValidator);
                paymentSchemeValidatorCreated.Add(paymentValidatorInstance.PaymentScheme);
            }

            var hasMissingValidators = allPaymentSchemes.Except(paymentSchemeValidatorCreated).Any();

            Assert.AreEqual(hasMissingValidators, false);
        }
    }
}
