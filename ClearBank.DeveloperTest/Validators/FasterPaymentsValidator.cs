using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Interfaces.Validators;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Validators
{
    public class FasterPaymentsValidator : IPaymentValidator
    {
        public PaymentScheme PaymentScheme => PaymentScheme.FasterPayments;

        public bool IsValid(MakePaymentRequest request, Account account)
        {
            return account != null &&
                account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments) &&
                account.Balance >= request.Amount &&
                request.Amount > 0;
        }
    }
}
