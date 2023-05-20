namespace DataAccess.Entities
{
    public class AcademicFormation
    {
        //public readonly object CandidateSkill;

        public int academicFormationId { get; set; }
        public int candidateId { get; set; }
        public string institution { get; set; }
        public string degree { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Candidate Candidate { get; set; }
    }
}
