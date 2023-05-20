using DataAccess.Entities;
using DataAccess;
using Services.Service.IService;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities.DataToObject;
using DataAccess.ExtensionMethods;

namespace Services.Service
{
    public class CandidateSkillService : ICandidateSkillService
    {
        private readonly MyDbContext _dbContext;

        public CandidateSkillService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CandidateSkill>> GetAll()
        {
            var candidatoSkill = await _dbContext.candidateSkills
       .Include(c => c.Skill)
       .Include(c => c.Candidate)
       //.Include(c => c.JobApplication)
       .ToListAsync();

            return candidatoSkill;
            //List<CandidateSkill> Lista = await _dbContext.candidateSkills.ToListAsync();
            //List<CandidateSkillVM> ListaVM = new List<CandidateSkillVM>();

            //foreach (CandidateSkill candidateSkill in Lista)
            //{
            //    CandidateSkillVM newCandidateSkillVm = new CandidateSkillVM();
            //    newCandidateSkillVm.SkillId = candidateSkill.SkillId;
            //    newCandidateSkillVm.CandidateId = candidateSkill.CandidateId;
            //    ListaVM.Add(newCandidateSkillVm);
            //}

            //return ListaVM;
        }

        public async Task<CandidateSkill> Create(CandidateSkillVM candidateSkillVM)
        {
            CandidateSkill candidateSkill;
            candidateSkill = candidateSkillVM.toCandidateSkill();
            _dbContext.candidateSkills.Add(candidateSkill);
            await _dbContext.SaveChangesAsync();
            return candidateSkill;
        }

        public async Task<bool> Delete(int id)
        {
            CandidateSkill candidateSkill = await _dbContext.candidateSkills.FindAsync(id);

            if (candidateSkill == null)
            {
                return false;
            }

            _dbContext.candidateSkills.Remove(candidateSkill);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CandidateSkill> Update(int id, CandidateSkillVM candidateSkillVM)
        {
            CandidateSkill existingCandidateSkill = await _dbContext.candidateSkills.FindAsync(id);

            if (existingCandidateSkill == null)
            {
                return null; // Retorna null si no se encuentra el candidato existente
            }

            existingCandidateSkill.CandidateId = candidateSkillVM.CandidateId;
            existingCandidateSkill.SkillId = candidateSkillVM.SkillId;

            _dbContext.Entry(existingCandidateSkill).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return existingCandidateSkill;
            //var existingAcaSkill = await _dbContext.candidateSkills.FindAsync(id);
            //if (existingAcaSkill == null)
            //{
            //    return null;
            //}

            //existingAcaSkill = candidateSkillVM.toCandidateSkill();
            //await _dbContext.SaveChangesAsync();
            //return existingAcaSkill;
        } 

    }
}
