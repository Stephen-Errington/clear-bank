using ClearBank.DeveloperTest.Interfaces.DataStores;

namespace ClearBank.DeveloperTest.Interfaces.Factories
{
    public interface IAccountDataStoreFactory
    {
        IAccountDataStore GetInstance();
    }
}
