using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Interfaces.Services
{
    public interface IPaymentService
    {
        MakePaymentResult MakePayment(MakePaymentRequest request);
    }
}
