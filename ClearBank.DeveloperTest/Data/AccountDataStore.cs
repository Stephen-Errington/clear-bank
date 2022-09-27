using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Interfaces.DataStores;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountDataStore : IAccountDataStore
    {
        public AccountDataStoreType AccountDataStoreType => AccountDataStoreType.Normal;

        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account();
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
