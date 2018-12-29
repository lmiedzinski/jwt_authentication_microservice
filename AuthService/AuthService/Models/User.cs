using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Models
{
    public class User
    {
        public User()
        {
            Roles = new List<ObjectId>();
        }

        public ObjectId Id { get; set; }

        [BsonElement("Login")]
        public string Login { get; set; }

        [BsonElement("PasswordHash")]
        public string PasswordHash { get; set; }

        [BsonElement("Roles")]
        public ICollection<ObjectId> Roles { get; set; }
    }
}
