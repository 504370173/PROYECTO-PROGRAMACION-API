using DataAccess.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Service.IService;
using DataAccess.Entities.RequestObjects;
using DataAccess.ExtensionMethods;

namespace Services.Service
{
    public class AcademicFormationService : IAcademicFormationService
    {
        private readonly MyDbContext _myDbContext;
        public AcademicFormationService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public Task<List<AcademicFormation>> GetAll()
        {
            return _myDbContext.academicFormations.ToListAsync();
        }
        public async Task<AcademicFormation> Create(AcademicFormationVM academicFormationVM)
        {
            AcademicFormation newAcademicFormation; //= new AcademicFormation();
            newAcademicFormation = academicFormationVM.toAcademicFormation();
            _myDbContext.academicFormations.Add(newAcademicFormation);
            await _myDbContext.SaveChangesAsync();
            return newAcademicFormation;
        }
        public async Task<bool> Delete(int id)
        {
            AcademicFormation academicFormation = await _myDbContext.academicFormations.FindAsync(id);

            if (academicFormation == null)
            {
                return false;
            }

            _myDbContext.academicFormations.Remove(academicFormation);
            await _myDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<AcademicFormation> Update(int id, AcademicFormationVM academicFormationVM)
        {
            var existingAcademic = await _myDbContext.academicFormations.FindAsync(id);
            if (existingAcademic == null)
            {
                return null;
            }

            existingAcademic = academicFormationVM.toAcademicFormation();
            await _myDbContext.SaveChangesAsync();
            return existingAcademic;
        }
    }
}
