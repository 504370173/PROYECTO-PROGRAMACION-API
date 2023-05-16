using DataAccess.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Service.IService;

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
        public async Task<AcademicFormation> Create(AcademicFormation academicFormation)
        {
            _myDbContext.academicFormations.Add(academicFormation);
            await _myDbContext.SaveChangesAsync();
            return academicFormation;
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

        public async Task<AcademicFormation> Update(int id, AcademicFormation academicFormation)
        {
            var existingAcademic = await _myDbContext.academicFormations.FindAsync(id);
            if (existingAcademic == null)
            {
                return null;
            }

            existingAcademic.institution = academicFormation.institution;
            existingAcademic.degree = academicFormation.degree;
            existingAcademic.startDate = academicFormation.startDate;
            existingAcademic.endDate = academicFormation.endDate;

            await _myDbContext.SaveChangesAsync();

            return existingAcademic;
        }
    }
}
