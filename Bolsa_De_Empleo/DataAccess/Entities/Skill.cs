using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string name { get; set; }
        public List<CandidateSkill> CandidateSkill { get; set; }
        //public List<OfferedSkill> offeredSkill { get; set; }

    }
}
