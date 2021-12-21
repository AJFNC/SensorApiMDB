using MongoDB.Bson;

using MongoDB.Bson.Serialization.Attributes;

namespace SensorApiMDB.Models
{
    public class Sensor
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Owner { get; set; }
        public int S { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }

    }
}
