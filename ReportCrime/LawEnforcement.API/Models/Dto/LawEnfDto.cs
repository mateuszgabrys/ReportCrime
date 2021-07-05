using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcement.API.Models.Dto
{
    public class LawEnfDto
    {
        public string LawEnfId { get; set; }
        public RankOfLawEnforcement RankOfLawEnforcement { get; set; } = RankOfLawEnforcement.Police;
        public IEnumerable<CrimeEventDto> CrimeEvents { get; set; }
    }
}
