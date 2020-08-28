using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatingApp.Entities
{
  public  class Profile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId ProfileId { get; set; }

        [BsonElement("First Name")]
        [BsonRequired]
        public String FirstName { get; set; }

        [BsonElement("Last Name")]
        [BsonRequired]
        public String LastName { get; set; }

        [BsonElement("Gender")]
        [BsonRequired]
        public String Gender { get; set; }

        [BsonElement("Occupation")]
        [BsonRequired]
        public String Occupation { get; set; }

        [BsonElement("Alternate Email")]
        [BsonRequired]
        public String AlternateEmail { get; set; }

        [BsonElement("Mobile Number")]
        [BsonRequired]
        public long MobileNumber { get; set; }
    }
}
