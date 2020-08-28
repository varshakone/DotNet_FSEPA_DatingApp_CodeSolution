using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatingApp.Entities
{
 public class User
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId UserId { get; set; }

        [BsonElement("User Name")]
        [BsonRequired]
        public String UserName { get; set; }

        [BsonElement("Password")]
        [BsonRequired]
        public String Password { get; set; }

        [BsonElement("Email")]
        [BsonRequired]
        public String Email { get; set; }

        [BsonElement("Mobile Number")]
        [BsonRequired]
        public long MobileNumber { get; set; }

        [BsonElement("User Type")]
        [BsonRequired]
        public UserType UserType { get; set; }

        [BsonElement("User Status")]
        [BsonRequired]
        public UserStatus UserStatus { get; set; }
    }
}
