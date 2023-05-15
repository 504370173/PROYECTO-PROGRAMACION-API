using DataAccess.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;

using Services.Service.IService;

namespace Services.Service
{
    internal class AcademicFormationService : IAcademicFormationService
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
    }
}
