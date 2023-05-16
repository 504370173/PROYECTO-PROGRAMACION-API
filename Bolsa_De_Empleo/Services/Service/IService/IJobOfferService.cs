using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.IService
{
    public interface IJobOfferService
    {
        public Task<List<JobOffer>> GetAll();
        public Task<JobOffer> Create(JobOffer jobOffer);
        public Task<JobOffer> Update(int id, JobOffer jobOffer);

        public Task<bool> Delete(int id);
    }
}

