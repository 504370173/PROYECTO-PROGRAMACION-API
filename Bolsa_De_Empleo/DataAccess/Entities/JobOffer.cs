﻿namespace DataAccess.Entities
{
    public class JobOffer
    {
        public int jobOfferId { get; set; }
        public int companyId { get; set; }
        public string position { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool status { get; set; }
        public Company Company { get; set; }
        public List<JobApplication> JobApplication { get; set; }
        public List<OfferSkill> OfferSkill { get; set; }

    }
}
