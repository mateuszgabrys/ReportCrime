using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crime.API.Models
{
    public class CrimeEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CrimeId { get; set; }
        public TypeOfEvent TypeOfEvent { get; set; } = TypeOfEvent.Assault;
        public string Description { get; set; }
        public string PlaceOfEvent { get; set; }
        public string ReportingPersonEmail { get; set; }
        public StatusEvent Status { get; set; } = StatusEvent.Waiting;
        public string LawEnforcementId { get; set; }
    }
}
