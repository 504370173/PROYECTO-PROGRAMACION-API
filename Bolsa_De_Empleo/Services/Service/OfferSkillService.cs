using DataAccess.Entities;
using DataAccess;
using Services.Service.IService;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities.DataToObject;
using DataAccess.ExtensionMethods;

namespace Services.Service
{
    public class OfferSkillService : IOfferSkillService
    {
        private readonly MyDbContext _dbContext;

        public OfferSkillService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OfferSkill>> GetAll()
        {
            var offerSkill = await _dbContext.OfferedSkills
       .Include(c => c.Skill)
       .Include(c => c.JobOffer)
       //.Include(c => c.JobApplication)
       .ToListAsync();

            return offerSkill;
        }

        public async Task<OfferSkill> Create(OfferSkillVM OfferSkillVM)
        {
            OfferSkill offerSkill;
            offerSkill = OfferSkillVM.toOfferSkill();
            _dbContext.OfferedSkills.Add(offerSkill);
            await _dbContext.SaveChangesAsync();
            return offerSkill;
        }

        public async Task<bool> Delete(int id)
        {
            OfferSkill offerSkill = await _dbContext.OfferedSkills.FindAsync(id);

            if (offerSkill == null)
            {
                return false;
            }

            _dbContext.OfferedSkills.Remove(offerSkill);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<OfferSkill> Update(int id, OfferSkillVM offerSkillVM)
        {
            OfferSkill existingOfferSkill = await _dbContext.OfferedSkills.FindAsync(id);

            if (existingOfferSkill == null)
            {
                return null; // Retorna null si no se encuentra el candidato existente
            }

            existingOfferSkill.SkillId = offerSkillVM.SkillId;
            existingOfferSkill.jobOfferId = offerSkillVM.jobOfferId;


            _dbContext.Entry(existingOfferSkill).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return existingOfferSkill;
        
        }
    }
}
