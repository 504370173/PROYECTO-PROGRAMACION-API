using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace Services.Service.IService
{
    public interface ICompanyService
    {
        public Task<List<Company>> GetAll();
        public Task<Company> Create(CompanyVM companyVM);
        public Task<Company> Update(int id, CompanyVM companyVM);
        public Task<bool> Delete(int id);
    }
}


