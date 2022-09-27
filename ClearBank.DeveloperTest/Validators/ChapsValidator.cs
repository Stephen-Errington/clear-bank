using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Interfaces.Validators;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Validators
{
    public class ChapsValidator : IPaymentValidator
    {
        public PaymentScheme PaymentScheme => PaymentScheme.Chaps;

        public bool IsValid(MakePaymentRequest request, Account account)
        {
            return account != null &&
                account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) &&
                account.Status == AccountStatus.Live &&
                request.Amount > 0;
        }
    }
}
