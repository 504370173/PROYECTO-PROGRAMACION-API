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

        public Task<List<JobOffer>> GetAll()
        {
            return _myDbContext.jobOffers.ToListAsync();
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

            var e = await _myDbContext.jobOffers.FindAsync(id);

            if (e == null)
            {
                return null;
            }

            e = jobOfferVM.toJobOffer();
            await _myDbContext.SaveChangesAsync();
            return e;
        }

    }
}
