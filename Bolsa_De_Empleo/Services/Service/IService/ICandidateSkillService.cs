using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace Services.Service.IService
{
    public interface ICandidateSkillService
    {
        public Task<List<CandidateSkill>> GetAll();
        public Task<CandidateSkill> Create(CandidateSkillVM candidateSkillVM);
        public Task<CandidateSkill> Update(int id, CandidateSkillVM candidateSkillVM);
        public Task<bool> Delete(int id);
    }
}

