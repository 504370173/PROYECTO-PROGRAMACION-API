using DataAccess.Entities;
using DataAccess.Entities.DataToObject;

namespace Services.Service.IService
{
    public interface IJobOfferService
    {
        public Task<List<JobOffer>> GetAll();
        public Task<JobOffer> Create(JobOfferVM jobOfferVM);
        public Task<JobOffer> Update(int id, JobOfferVM jobOfferVM);

        public Task<bool> Delete(int id);
    }
}

