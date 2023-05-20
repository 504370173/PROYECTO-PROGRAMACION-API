using DataAccess.Entities;
using DataAccess.Entities.RequestObjects;

namespace DataAcces
{
    public static class ToCandidateExtension
    {
        public static Candidate toCandidate(this CandidateVM obj) 
        {
            Candidate candidate = new Candidate();
            candidate.name = obj.name;
            candidate.lastName1 = obj.lastName1;
            candidate.lastName2 = obj.lastName2;
            candidate.email = obj.email;
            candidate.phoneNumber = obj.phoneNumber;
            candidate.summary = obj.summary;
            candidate.createdAt = obj.createdAt;
            candidate.updatedAt = obj.updatedAt;
            candidate.status = obj.status;
            return candidate;
        }
    }
}
