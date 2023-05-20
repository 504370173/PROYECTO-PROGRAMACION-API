using DataAccess;
using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using DataAccess.ExtensionMethods;
using Microsoft.EntityFrameworkCore;
using Services.Service.IService;

namespace Services.Service
{
    public class SkillService : ISkillService
    {
        private readonly MyDbContext _myDbContext;
        public SkillService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        public Task<List<Skill>> GetAll()
        {
            //var skill = await _myDbContext.skills.ToListAsync();
            //foreach (var c in skill)
            //{
            //    await _myDbContext.Entry(c).Collection(a => a.CandidateSkill).LoadAsync();
            //}

            //return skill;
            return _myDbContext.skills.ToListAsync();
        }

        public async Task<Skill> Create(SkillVM skillVM)
        {
            Skill skill;
            skill = skillVM.toSkill();
            _myDbContext.skills.Add(skill);
            await _myDbContext.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> Delete(int id)
        {
            Skill skill = await _myDbContext.skills.FindAsync(id);

            if (skill == null)
            {
                return false;
            }

            _myDbContext.skills.Remove(skill);
            await _myDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Skill> Update(int id, SkillVM skillVM)
        {
            var existingSkill = await _myDbContext.skills.FindAsync(id);

            if (existingSkill == null)
            {
                return null;
            }


            existingSkill = skillVM.toSkill();
            await _myDbContext.SaveChangesAsync();
            return existingSkill;
        }

    }
}
