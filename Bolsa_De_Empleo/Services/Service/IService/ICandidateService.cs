using DataAccess.Entities;
using DataAccess.Entities.RequestObjects;

namespace Services.Service.IService
{
    public interface ICandidateService
    {
        public Task<List<Candidate>> GetAll();
        public Task<Candidate> Create(CandidateVM candidateVM);
        public Task<Candidate> Update(int id, CandidateVM candidateVM);
        public Task<bool> Delete(int id);
    }
}
