using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Finance.ASP.Common
{
    public class ServiceHepler
    {
        public MongoClient Client;
        public IMongoDatabase Database;

        MongoDBSettings _options;

        public ServiceHepler(IOptions<MongoDBSettings> options)
        {
            _options = options.Value;

            if (_options != null)
            {
                Client = new MongoClient(_options.ConnectionURI);
                Database = Client.GetDatabase(_options.DatabaceName);
            }
        }

        public IMongoCollection<T> GetCollection<T>() where T : class
        {
            if (_options is null)
                throw new InvalidOperationException("Options is null");

            return Database.GetCollection<T>(_options.CollectionName);
        }
    }
}
