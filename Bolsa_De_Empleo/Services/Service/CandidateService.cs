using DataAcces;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Entities.RequestObjects;
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
        public async Task<List<Candidate>> GetAll()
        {
            var candidato = await _myDbContext.candidates.ToListAsync();

            foreach (var can in candidato) 
            {
                await _myDbContext.Entry(can).Collection(a => a.AcademicFormation).LoadAsync();
                await _myDbContext.Entry(can).Collection(a => a.CandidateSkill).LoadAsync();

            }

            return candidato;
            //return _myDbContext.candidates
            //.Include("AcademicFormation")
            ////.ThenInclude(t => t.CandidateSkill)
            //.ToListAsync();
        }
        public async Task<Candidate> Create(CandidateVM candidateVM) 
        {
            Candidate newCandidate; //= new Candidate();
            newCandidate = candidateVM.toCandidate();
            _myDbContext.candidates.Add(newCandidate);
            await _myDbContext.SaveChangesAsync();
            return newCandidate;
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

        public async Task<Candidate> Update(int id, CandidateVM candidateVM)
        {
            Candidate c = await _myDbContext.candidates.FindAsync(id);
             c = candidateVM.toCandidate();

            _myDbContext.Entry(c).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return c;
            //var existingCandidate = await _myDbContext.candidates.FindAsync(id);

            //if (existingCandidate == null)
            //{
            //    return null;
            //}

            //existingCandidate = candidateVM.toCandidate();
            //await _myDbContext.SaveChangesAsync();
            //return existingCandidate;
        }
    }
}
