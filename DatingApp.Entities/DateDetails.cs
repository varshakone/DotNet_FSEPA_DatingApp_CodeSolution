using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatingApp.Entities
{
    public class DateDetails
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId DateId { get; set; }

        [BsonElement("Request Sender Name")]
        [BsonRequired]
        public String RequestSenderName { get; set; }

        [BsonElement("Request Receiver Name")]
        [BsonRequired]
        public String RequestReceiverName { get; set; }

        [BsonElement("Date Of Request")]
        [BsonRequired]
        public String DateOfRequest { get; set; }

        [BsonElement("Request Status")]
        [BsonRequired]
        public Status RequestStatus { get; set; }

        [BsonElement("Request Sender Email")]
        [BsonRequired]
        public String RequestSenderEmail { get; set; }

        [BsonElement("Request Receiver Email")]
        [BsonRequired]
        public String RequestReceiverEmail { get; set; }

        [BsonElement("Mobile")]
        [BsonRequired]
        public long Mobile { get; set; }

        [BsonElement("Request Message")]
        [BsonRequired]
        public String RequestMessage { get; set; }
    }
}