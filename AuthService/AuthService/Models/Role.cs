using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Models
{
    public class Role
    {
        public static readonly string ADMIN_ROLE_NAME = "admin";
        public static readonly string USER_ROLE_NAME = "user";

        public ObjectId Id { get; set; }

        [BsonElement("RoleName")]
        public string RoleName { get; set; }

    }
}
