using DataAccess.Entities;
using DataAccess.Entities.DataToObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
