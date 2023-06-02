using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Finance.ASP.Services
{
    public class SpendingService
    {
        private readonly IMongoCollection<Spending> _collection;

        public SpendingService(IOptions<MongoDBSettings> options)
        {
            _collection = new ServiceHepler(options).GetCollection<Spending>();
        }

        public async Task<List<Spending>> GetAsync()
        {
            return await _collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Spending spending)
        {
            await _collection.InsertOneAsync(spending);
            return;
        }

        public async Task ChangeAmountAsync(string id, int newAmount)
        {
            FilterDefinition<Spending> filter = Builders<Spending>.Filter.Eq("Id", id);
            UpdateDefinition<Spending> update = Builders<Spending>.Update.Set(x => x.amount, newAmount);
            await _collection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Spending> filter = Builders<Spending>.Filter.Eq("Id", id);
            await _collection.DeleteOneAsync(filter);
            return;
        }
    }
}
