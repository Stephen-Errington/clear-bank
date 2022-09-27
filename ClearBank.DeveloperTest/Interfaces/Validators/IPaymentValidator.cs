using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Interfaces.Validators
{
    public interface IPaymentValidator
    {
        PaymentScheme PaymentScheme { get; }

        bool IsValid(MakePaymentRequest request, Account account);
    }
}
