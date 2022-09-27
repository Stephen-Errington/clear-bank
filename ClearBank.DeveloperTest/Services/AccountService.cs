using ClearBank.DeveloperTest.Interfaces.DataStores;
using ClearBank.DeveloperTest.Interfaces.Factories;
using ClearBank.DeveloperTest.Interfaces.Services;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataStore _accountDataStore;
        public AccountService(IAccountDataStoreFactory accountDataStoreFactory)
        {
            _accountDataStore = accountDataStoreFactory.GetInstance();
        }

        public Account GetAccount(string accountNumber)
        {
            return _accountDataStore.GetAccount(accountNumber);
        }

        public void UpdateAccount(Account account)
        {
            _accountDataStore.UpdateAccount(account);
        }
    }
}
