using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace DataAccess.ExtensionMethods
{
    public static class ToJobApplication
    {
        public static JobApplication toJobApplication(this JobApplicationVM obj)
        {
            JobApplication newJobApplication = new()
            {
                CandidateId = obj.CandidateId,
                jobOfferId = obj.jobOfferId
            };
            return newJobApplication;
        }
    }
}
