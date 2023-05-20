namespace DataAccess.Entities
{
    public class OfferSkill
    {
        //public int Id { get; set; }
        public int SkillId { get; set; }
        public int jobOfferId { get; set; }
        public Skill Skill { get; set; }
        public JobOffer JobOffer { get; set; }

    }
}
