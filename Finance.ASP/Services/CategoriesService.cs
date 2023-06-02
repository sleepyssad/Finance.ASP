namespace Finance.ASP.Services
{
    public class CategoriesService : BaceService<Categories>
    {
        public CategoriesService(IOptions<MongoDBSettings> options) 
        {
            SetCollection(options, options.Value.Collections.Categories);  
        }

        public async Task<List<Categories>> GetAsync()
        {
            return await GetCollection().Find(new BsonDocument()).ToListAsync();
        }
    }
}
