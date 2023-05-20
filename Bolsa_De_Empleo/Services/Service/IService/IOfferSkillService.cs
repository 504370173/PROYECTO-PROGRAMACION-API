using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace Services.Service.IService
{
    public interface IOfferSkillService
    {
        public Task<List<OfferSkill>> GetAll();
        public Task<OfferSkill> Create(OfferSkillVM OfferSkillVM);
        public Task<OfferSkill> Update(int id, OfferSkillVM OfferSkillVM);
        public Task<bool> Delete(int id);
    }
}
