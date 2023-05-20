using DataAccess.Entities.DataToObject;
using DataAccess.Entities;


namespace Services.Service.IService
{
    public interface IJobApplicationService
    {
        public Task<List<JobApplication>> GetAll();
        public Task<JobApplication> Create(JobApplicationVM jobApplicationVM);
        public Task<JobApplication> Update(int id, JobApplicationVM jobApplicationVM);
        public Task<bool> Delete(int id);
    }
}
