namespace Finance.ASP.Services
{
    public class BaceService<T> : Controller where T : class
    {
        private protected MongoClient _client;
        private protected IMongoDatabase _database;
        private protected MongoDBSettings _options;

        private IMongoCollection<T> __collection;

        public BaceService(IOptions<MongoDBSettings> options, string collectionName)
        {
            _options = options.Value;

            if (_options != null)
            {
                _client = new MongoClient(_options.ConnectionURI);
                _database = _client.GetDatabase(_options.DatabaceName);

                __collection = _database.GetCollection<T>(collectionName);
            }
        }

        private protected IMongoCollection<T> GetCollection()
        {
            if (__collection is null)
                throw new InvalidOperationException("Collection is null");

            return __collection;
        }
    }
}
