using LawEnforcement.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcement.API.Models
{
    public class CrimeEvent
    {
        [Key]
        public string CrimeId { get; set; }
        public TypeOfEvent TypeOfEvent { get; set; } = TypeOfEvent.Assault;
        public string Description { get; set; }
        public string PlaceOfEvent { get; set; }
        public string ReportingPersonEmail { get; set; }
        public StatusEvent Status { get; set; } = StatusEvent.Waiting;
        public string LawEnforcementId { get; set; }
    }
}
