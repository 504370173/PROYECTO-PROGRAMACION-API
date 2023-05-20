namespace DataAccess.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string name { get; set; }
        public List<CandidateSkill> CandidateSkill { get; set; }
        public List<OfferSkill> OfferedSkill { get; set; }

    }
}
