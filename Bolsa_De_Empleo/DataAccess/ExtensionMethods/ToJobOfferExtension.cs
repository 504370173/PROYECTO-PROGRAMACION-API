using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace DataAccess.ExtensionMethods
{
    public static class ToJobOfferExtension
    {
        public static JobOffer toJobOffer(this JobOfferVM obj)
        {
            JobOffer jobOffer = new JobOffer();
            jobOffer.position = obj.position;
            jobOffer.description = obj.description;
            jobOffer.createdAt = obj.createdAt;
            jobOffer.updatedAt = obj.updatedAt;
            jobOffer.status = obj.status;
            jobOffer.companyId = obj.companyId;
            return jobOffer;
        }
    }
}
