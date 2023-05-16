using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.IService
{
    public interface IAcademicFormationService
    {
        public Task<List<AcademicFormation>> GetAll();
        public Task<AcademicFormation> Create(AcademicFormation academicFormation);
        public Task<AcademicFormation> Update(int id, AcademicFormation academicFormation);

        public Task<bool> Delete(int id);

    }
}
