﻿using DataAccess.Entities;
using DataAccess;
using Services.Service.IService;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities.DataToObject;
using DataAccess.ExtensionMethods;

namespace Services.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly MyDbContext _dbContext;
        public CompanyService(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Company>> GetAll()
        {
            var company = await _dbContext.companies
      .Include(c => c.JobOffer)
      //.Include(c => c.CandidateSkill)
      //.Include(c => c.JobApplication)
      .ToListAsync();

            return company;
            //var company = await _dbContext.companies.ToListAsync();
            //foreach (var c in company)
            //{
            //    await _dbContext.Entry(c).Collection(a => a.JobOffer).LoadAsync();
            //}

            //return company;
        }

        public async Task<Company> Create(CompanyVM companyVM)
        {
            Company company;// = new Company();
            company = companyVM.toCompany();
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

        public async Task<Company> Update(int id, CompanyVM companyVM)
        {
            Company e = await _dbContext.companies.FindAsync(id);
            
            if (e == null) 
            {
                return null;
            }
            e.Name = companyVM.Name;
            e.email = companyVM.email;
            e.phoneNumber = companyVM.phoneNumber;
            e.webSite = companyVM.webSite;

            _dbContext.Entry(e).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return e;
        }
    }
}

