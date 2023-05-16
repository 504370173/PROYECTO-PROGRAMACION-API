using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.IService
{
    public interface ICompanyService
    {
        public Task<List<Company>> GetAll();
        public Task<Company> Create(Company company);
        public Task<Company> Update(int id, Company company);
        public Task<bool> Delete(int id);
    }
}


