namespace DataAccess.Entities
{
    public class Company
    {
        public int companyId { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string webSite { get; set; }
        public List<JobOffer> JobOffer { get; set; }
        //public List<CompanySkill> CompanySkills { get; set; }

    }
}
