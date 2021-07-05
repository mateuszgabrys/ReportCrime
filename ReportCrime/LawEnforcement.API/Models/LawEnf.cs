using LawEnforcement.API.Models.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcement.API.Models
{
    public class LawEnf
    {
        [Key]
        public string LawEnfId { get; set; }
        public RankOfLawEnforcement RankOfLawEnforcement { get; set; } = RankOfLawEnforcement.Police;
        public IEnumerable<CrimeEventDto> CrimeEvents { get; set; }
    }
}
