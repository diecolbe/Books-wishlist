using challenge.emision.Domain.Entities.Security;
using challenge.emision.MongoDb.Interfaces;
using challenge.emision.MongoDb.Repositories;
using MongoDB.Bson;

namespace challenge.emision.MongoDb.Documents
{
    [BsonCollection("Users")]
    public class UserDocument : User, IDocument
    {
        public UserDocument() { }
        public UserDocument(User user)
        {
            Username = user.Username;
            PasswordHash = user.PasswordHash;
            PasswordSalt=user.PasswordSalt;
        }
        public ObjectId Id { get; set; }

        public DateTime CreationDate => Id.CreationTime;
    }
}
