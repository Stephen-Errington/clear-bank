using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Interfaces.Validators;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Validators
{
    public class BacsValidator : IPaymentValidator
    {
        public PaymentScheme PaymentScheme => PaymentScheme.Bacs;

        public bool IsValid(MakePaymentRequest request, Account account)
        {
            return account != null &&
                account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs) &&
                request.Amount > 0;
        }
    }
}
