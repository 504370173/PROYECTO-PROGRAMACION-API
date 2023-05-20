using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

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
