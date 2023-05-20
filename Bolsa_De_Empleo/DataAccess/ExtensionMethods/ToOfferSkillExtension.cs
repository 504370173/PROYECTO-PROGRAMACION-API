using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace DataAccess.ExtensionMethods
{
    public static class ToOfferSkillExtension
    {
        public static OfferSkill toOfferSkill(this OfferSkillVM obj)
        {
            OfferSkill offerSkill = new OfferSkill();
            offerSkill.SkillId = obj.SkillId;
            offerSkill.jobOfferId = obj.jobOfferId;
            return offerSkill;
        }
    }
}
