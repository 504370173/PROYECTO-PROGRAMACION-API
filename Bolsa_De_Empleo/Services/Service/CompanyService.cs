using DataAccess.Entities;
using DataAccess;
using Services.Service;

using Services.Service.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Services.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly MyDbContext _dbContext;
        public CompanyService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Company>> GetAll()
        {
            return _dbContext.companies.Include("JobOffer").ToListAsync();
        }

        public async Task<Company> Create(Company company)
        {
            _dbContext.companies.Add(company);
            await _dbContext.SaveChangesAsync();
            return company;
        }
        
        public async Task<bool> Delete(int id)
        {
            Company company = await _dbContext.companies.FindAsync(id);
            
            if (company == null) 
            {
                return false;
            }

            _dbContext.companies.Remove(company);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Company> Update(int id, Company company)
        {
            var e = await _dbContext.companies.FindAsync(id);
            
            if (e == null) 
            {
                return null;
            }

            e.Name = company.Name;
            e.email = company.email;
            e.phoneNumber = company.phoneNumber;
            e.webSite = company.webSite;

            await _dbContext.SaveChangesAsync();
            return e;
        }
    }
}

