using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace Services.Service.IService
{
    public interface ISkillService
    {
        public Task<List<Skill>> GetAll();
        public Task<Skill> Create(SkillVM skillVM);
        public Task<Skill> Update(int id, SkillVM skillVM);
        public Task<bool> Delete(int id);
    }
}
