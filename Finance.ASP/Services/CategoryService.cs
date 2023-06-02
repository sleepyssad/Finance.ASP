namespace Finance.ASP.Services
{
    public class CategoryService : BaceService<Category>
    {
        public CategoryService(IOptions<MongoDBSettings> options) : base(options, options.Value.Collections.Categories) 
        {
        }

        public async Task<List<Category>> GetAsync()
        {
            return await GetCollection().Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Category category)
        {
           
            await GetCollection().InsertOneAsync(category);
            return;
        }

        public async Task ChangeAsync(string id, string newName)
        {
            var filter = Builders<Category>.Filter.Eq("Id", id);
            var update = Builders<Category>.Update.Set(x =>  x.name, newName);
            await GetCollection().UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Category>.Filter.Eq("Id", id);
            await GetCollection().DeleteOneAsync(filter);
            return;
        }
    }
}
