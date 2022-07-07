using challenge.emision.MongoDb.Interfaces;
using MongoDB.Bson;

namespace challenge.emision.MongoDb.Documents
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreationDate => Id.CreationTime;
    }
}
