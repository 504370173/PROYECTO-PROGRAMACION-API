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

        public async Task<bool> Delete(int id)
        {
            Candidate candidate = await _myDbContext.candidates.FindAsync(id);

            if(candidate == null) 
            {
                return false;
            }

            _myDbContext.candidates.Remove(candidate);
            await _myDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Candidate> Update(int id, Candidate candidate)
        {
            var existingCandidate = await _myDbContext.candidates.FindAsync(id);
            if (existingCandidate == null)
            {
                return null;
            }

            existingCandidate.name = candidate.name;
            existingCandidate.lastName1 = candidate.lastName1;
            existingCandidate.lastName2 = candidate.lastName2;
            existingCandidate.email = candidate.email;
            existingCandidate.phoneNumber = candidate.phoneNumber;
            existingCandidate.summary = candidate.summary;
            existingCandidate.createdAt = candidate.createdAt;
            existingCandidate.updatedAt = candidate.updatedAt;
            existingCandidate.status = candidate.status;

            await _myDbContext.SaveChangesAsync();

            return existingCandidate;
        }
    }
}
