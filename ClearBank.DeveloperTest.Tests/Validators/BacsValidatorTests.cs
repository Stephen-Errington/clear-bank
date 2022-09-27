using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Models;
using ClearBank.DeveloperTest.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClearBank.DeveloperTest.Tests.Validators
{
    [TestClass]
    public class BacsValidatorTests
    {
        private BacsValidator _bacsValidator;

        [TestInitialize]
        public void TestInitialise()
        {
            _bacsValidator = new BacsValidator();
        }

        [TestMethod]
        public void PaymentType_IsBacs()
        {
            _bacsValidator.PaymentScheme.Equals(PaymentScheme.Bacs);
        }

        [TestMethod]
        public void AccountFlagsIsOnlyBacs_ShouldBeTrue()
        {
            var request = new MakePaymentRequest();

            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };

            var isValid = _bacsValidator.IsValid(request, account);

            isValid.Equals(true);
        }

        [TestMethod]
        public void AccountFlagsHasNoBacs_ShouldBeFalse()
        {
            var request = new MakePaymentRequest();

            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments | AllowedPaymentSchemes.Chaps
            };

            var isValid = _bacsValidator.IsValid(request, account);

            isValid.Equals(false);
        }

        [TestMethod]
        public void AccountFlagsHasmixed_ShouldBeTrue()
        {
            var request = new MakePaymentRequest();

            var account = new Account
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments | AllowedPaymentSchemes.Bacs
            };

            var isValid = _bacsValidator.IsValid(request, account);

            isValid.Equals(true);
        }

        [TestMethod]
        public void AccountIsNull_ShouldBeFalse()
        {
            var request = new MakePaymentRequest();

            Account account = null;

            var isValid = _bacsValidator.IsValid(request, account);

            isValid.Equals(false);
        }
    }
}
