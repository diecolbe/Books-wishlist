using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace challenge.emision.MongoDb.Interfaces
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id { get; set; }
        DateTime CreationDate { get; }
    }
}
