namespace DataAccess.Entities
{
    public class Candidate
    {
        public int candidateId { get; set; }
        public string name { get; set;}
        public string lastName1 { get; set;}
        public string lastName2 { get; set;}
        public string email { get; set;}
        public int phoneNumber { get; set;}
        public string summary { get; set;}
        public DateTime createdAt { get; set;}
        public DateTime updatedAt { get; set;}
        public bool status { get; set;}

        public List<AcademicFormation> AcademicFormation { get; set; }
        public List<CandidateSkill> CandidateSkill { get; set; }
        public List<JobApplication> JobApplication { get; set; }

    }
}
