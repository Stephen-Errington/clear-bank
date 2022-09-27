using System.Linq;
using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Interfaces.Factories;
using ClearBank.DeveloperTest.Interfaces.Validators;

namespace ClearBank.DeveloperTest.Factories
{
    public class PaymentValidatorFactory : IPaymentValidatorFactory
    {
        private readonly IPaymentValidator[] _paymentValidators;
        public PaymentValidatorFactory(IPaymentValidator[] paymentValidators)
        {
            _paymentValidators = paymentValidators;
        }

        public IPaymentValidator GetInstance(PaymentScheme paymentScheme)
        {
            return _paymentValidators.Single(x => x.PaymentScheme == paymentScheme);
        }
    }
}
