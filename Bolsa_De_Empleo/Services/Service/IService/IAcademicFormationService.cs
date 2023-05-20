using DataAccess.Entities;
using DataAccess.Entities.RequestObjects;

namespace Services.Service.IService
{
    public interface IAcademicFormationService
    {
        public Task<List<AcademicFormation>> GetAll();
        public Task<AcademicFormation> Create(AcademicFormationVM academicFormationVM);
        public Task<AcademicFormation> Update(int id, AcademicFormationVM academicFormationVM);

        public Task<bool> Delete(int id);

    }
}
