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
            var candidatos = await _myDbContext.candidates
       .Include(c => c.AcademicFormation)
       .Include(c => c.CandidateSkill)
       .Include(c => c.JobApplication)
       .ToListAsync();

            return candidatos;
            //var candidato = await _myDbContext.candidates.ToListAsync();

            //foreach (var can in candidato) 
            //{
            //    await _myDbContext.Entry(can).Collection(a => a.AcademicFormation).LoadAsync();
            //    await _myDbContext.Entry(can).Collection(a => a.CandidateSkill).LoadAsync();
            //    await _myDbContext.Entry(can).Collection(a => a.JobApplication).LoadAsync();


            //}

            //return candidato;
            //----*----
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
            Candidate existingCandidate = await _myDbContext.candidates.FindAsync(id);

            if (existingCandidate == null)
            {
                return null; // Retorna null si no se encuentra el candidato existente
            }

            existingCandidate.name = candidateVM.name;
            existingCandidate.lastName1 = candidateVM.lastName1;
            existingCandidate.lastName2 = candidateVM.lastName2;
            existingCandidate.email = candidateVM.email;
            existingCandidate.phoneNumber = candidateVM.phoneNumber;
            existingCandidate.summary = candidateVM.summary;
            existingCandidate.createdAt = DateTime.Now;
            existingCandidate.updatedAt = DateTime.Now;
            existingCandidate.status = candidateVM.status;

            _myDbContext.Entry(existingCandidate).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();

            return existingCandidate;
            //Candidate c = await _myDbContext.candidates.FindAsync(id);
            // c = candidateVM.toCandidate();

            //_myDbContext.Entry(c).State = EntityState.Modified;
            //await _myDbContext.SaveChangesAsync();
            //return c;

        }
    }
}
