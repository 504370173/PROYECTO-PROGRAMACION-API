using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ExtensionMethods
{
    public static class ToCandidateSkillExtension
    {
        public static CandidateSkill toCandidateSkill(this CandidateSkillVM obj)
        {
            CandidateSkill candidateSkill = new CandidateSkill();
            candidateSkill.CandidateId = obj.CandidateId;
            candidateSkill.SkillId = obj.SkillId;
            return candidateSkill;
        }
    }
}
