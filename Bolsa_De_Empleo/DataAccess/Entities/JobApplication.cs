namespace DataAccess.Entities
{
    public class JobApplication
    {
        //public int Id { get; set; }
        public int CandidateId { get; set; }
        public int jobOfferId { get; set; }
        public Candidate Candidate { get; set; }
        public JobOffer JobOffer { get; set; }
    }
}
