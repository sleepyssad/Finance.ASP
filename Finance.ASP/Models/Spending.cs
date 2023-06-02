using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Finance.ASP.Models
{
    public class Spending
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int amount { get; set; }

        public string currency { get; set; }

        public string description { get; set; }

        public string category { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime date { get; set; }
    }
}
