using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace DataAccess.ExtensionMethods
{
    public static class ToSkillExtension
    {
        public static Skill toSkill(this SkillVM obj)
        {
            Skill skill = new Skill();
            skill.name = obj.name;
            return skill;
        }
    }
}
