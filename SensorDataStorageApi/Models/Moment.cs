using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace SensorDataStorageApi.Models
{
    public class Moment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? Date { get; set; }

        [BsonElement("temperature")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Temperature { get; set; }

        [BsonElement("humidity")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Humidity { get; set; }
    }
}
