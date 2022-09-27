using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Models;

namespace ClearBank.DeveloperTest.Interfaces.DataStores
{
    public interface IAccountDataStore
    {
        AccountDataStoreType AccountDataStoreType { get; }

        Account GetAccount(string accountNumber);

        void UpdateAccount(Account account);
    }
}
