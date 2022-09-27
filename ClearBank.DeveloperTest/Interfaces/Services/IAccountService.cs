using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Interfaces.Services
{
    public interface IAccountService
    {
        Account GetAccount(string accountNumber);

        void UpdateAccount(Account account);
    }
}
