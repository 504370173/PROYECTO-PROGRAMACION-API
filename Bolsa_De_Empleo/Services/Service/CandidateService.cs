using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Service.IService;

namespace Services.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly MyDbContext _myDbContext;
        public CandidateService(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public Task<List<Candidate>> GetAll()
        {
            return _myDbContext.candidates.Include("AcademicFormation").ToListAsync();
        }
        public async Task<Candidate> Create(Candidate candidate) 
        {
            _myDbContext.candidates.Add(candidate);
            await _myDbContext.SaveChangesAsync();
            return candidate;
        }
    }
}
