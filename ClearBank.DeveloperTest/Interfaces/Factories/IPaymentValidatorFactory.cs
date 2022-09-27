using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Interfaces.Validators;

namespace ClearBank.DeveloperTest.Interfaces.Factories
{
    public interface IPaymentValidatorFactory
    {
        IPaymentValidator GetInstance(PaymentScheme paymentScheme);
    }
}
