namespace Finance.ASP.Services
{
    public class SpendingService : BaceService<Spending>
    {
        public SpendingService(IOptions<MongoDBSettings> options)
        {
            SetCollection(options, options.Value.Collections.Spending);
        }

        public async Task<List<Spending>> GetAsync()
        {
            return await GetCollection().Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Spending spending)
        {
            await GetCollection().InsertOneAsync(spending);
            return;
        }

        public async Task ChangeAmountAsync(string id, int newAmount)
        {
            var filter = Builders<Spending>.Filter.Eq("Id", id);
            var update = Builders<Spending>.Update.Set(x => x.amount, newAmount);
            await GetCollection().UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Spending>.Filter.Eq("Id", id);
            await GetCollection().DeleteOneAsync(filter);
            return;
        }
    }
}
