using ClearBank.DeveloperTest.Interfaces.Factories;
using ClearBank.DeveloperTest.Interfaces.Services;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountService _accountService;
        private readonly IPaymentValidatorFactory _paymentValidatorFactory;

        public PaymentService(IAccountService accountService, IPaymentValidatorFactory paymentValidatorFactory)
        {
            _accountService = accountService;
            _paymentValidatorFactory = paymentValidatorFactory;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var result = new MakePaymentResult();
            Account account = _accountService.GetAccount(request.DebtorAccountNumber);
            
            if (account != null)
            {
                var paymentValidator = _paymentValidatorFactory.GetInstance(request.PaymentScheme);
                var isValid = paymentValidator.IsValid(request, account);

                if (isValid)
                {
                    account.Balance -= request.Amount;
                    _accountService.UpdateAccount(account);
                    result.Success = isValid;
                }
            }

            return result;
        }
    }
}
