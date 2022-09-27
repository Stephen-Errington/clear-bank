using System.Linq;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Interfaces.DataStores;
using ClearBank.DeveloperTest.Interfaces.Factories;
using ClearBank.DeveloperTest.Models.Settings;
using Microsoft.Extensions.Options;

namespace ClearBank.DeveloperTest.Factories
{
    public class AccountDataStoreFactory : IAccountDataStoreFactory
    {
        private readonly IAccountDataStore[] _accountDataStores;
        private readonly ConfigSettings _configSettings;

        public AccountDataStoreFactory(IAccountDataStore[] accountDataStores, IOptions<ConfigSettings> configSettings)
        {
            _accountDataStores = accountDataStores;
            _configSettings = configSettings.Value;
        }

        public IAccountDataStore GetInstance()
        {
            return _accountDataStores.Single(x => x.AccountDataStoreType == _configSettings.AccountDataStoreType);
        }
    }
}
