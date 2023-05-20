using DataAccess.Entities;
using DataAccess.Entities.RequestObjects;

namespace DataAccess.ExtensionMethods
{
    public static class ToAcademicFormationExtension
    {
        public static AcademicFormation toAcademicFormation(this AcademicFormationVM obk)
        {
            AcademicFormation academicFormation = new AcademicFormation();
            academicFormation.institution = obk.institution;
            academicFormation.degree = obk.degree;
            academicFormation.startDate = obk.startDate;
            academicFormation.endDate = obk.endDate;
            academicFormation.candidateId = obk.candidateId;
            return academicFormation;
        }
    }
}
