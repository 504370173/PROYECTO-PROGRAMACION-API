using DataAccess.Entities;

namespace Services.Service.IService
{
    public interface ICandidateService
    {
        public Task<List<Candidate>> GetAll();
        public Task<Candidate> Create(Candidate candidate);
    }
}
