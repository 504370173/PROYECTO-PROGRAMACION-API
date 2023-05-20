using DataAccess.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Service.IService;
using DataAccess.Entities.DataToObject;
using DataAccess.ExtensionMethods;

namespace Services.Service
{
    public class JobOfferService : IJobOfferService
    {
        private readonly MyDbContext _myDbContext;
        public JobOfferService(MyDbContext myDbContext) 
        {
            _myDbContext = myDbContext;
        }

        public async Task<List<JobOffer>> GetAll()
        {
            var jobOffer = await _myDbContext.jobOffers
            .Include(c => c.JobApplication)
             //.Include(c => c.CandidateSkill)
             //.Include(c => c.JobApplication)
            .ToListAsync();

            return jobOffer;
            //var s = await _myDbContext.jobOffers.ToListAsync();
            //foreach (var c in s)
            //{
            //    await _myDbContext.Entry(c).Collection(a => a.JobApplication).LoadAsync();
            //}

            //return s;
            //return _myDbContext.jobOffers.ToListAsync();
        }
        public async Task<JobOffer> Create(JobOfferVM jobOfferVM)
        {
            JobOffer jobOffer;
            jobOffer = jobOfferVM.toJobOffer();
            _myDbContext.jobOffers.Add(jobOffer);
            await _myDbContext.SaveChangesAsync();
            return jobOffer;
        }
        public async Task<bool> Delete(int id)
        {
            JobOffer jobOffer = await _myDbContext.jobOffers.FindAsync(id);

            if (jobOffer == null)
            {
                return false;
            }

            _myDbContext.jobOffers.Remove(jobOffer);
            await _myDbContext.SaveChangesAsync();

            return true;
        }
        public async Task<JobOffer> Update(int id, JobOfferVM jobOfferVM)
        {

            JobOffer e = await _myDbContext.jobOffers.FindAsync(id);

            if (e == null)
            {
                return null;
            }

            e.position = jobOfferVM.position;
            e.description = jobOfferVM.description;
            e.createdAt = jobOfferVM.createdAt;
            e.updatedAt = jobOfferVM.updatedAt;
            e.status = jobOfferVM.status;
            e.companyId = jobOfferVM.companyId;

            _myDbContext.Entry(e).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return e;
        }

    }
}
