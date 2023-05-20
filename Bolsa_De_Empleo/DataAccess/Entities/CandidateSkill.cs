namespace DataAccess.Entities
{
    public class CandidateSkill
    {
        //public int CanSkillId { get; set; }
        public int CandidateId { get; set; }
        public int SkillId { get; set;}
        public Candidate Candidate { get; set; }
        public Skill Skill { get; set; }
    }
}
