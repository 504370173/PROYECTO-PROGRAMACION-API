using DataAccess.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Service.IService;

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
        public async Task<JobOffer> Create(JobOffer jobOffer)
        {
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
        public async Task<JobOffer> Update(int id, JobOffer jobOffer)
        {
            var existingOffer = await _myDbContext.jobOffers.FindAsync(id);

            if (existingOffer == null)
            {
                return null;
            }

            existingOffer.position = jobOffer.position;
            existingOffer.description = jobOffer.description;
            existingOffer.createdAt = jobOffer.createdAt;
            existingOffer.updatedAt = jobOffer.updatedAt;
            existingOffer.status = jobOffer.status;

            await _myDbContext.SaveChangesAsync();

            return existingOffer;
        }

    }
}
