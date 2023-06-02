namespace Finance.ASP.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaceName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}
