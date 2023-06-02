namespace Finance.ASP.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaceName { get; set; } = null!;
        public MongoDBCollections Collections { get; set; } = null!;
    }
}
