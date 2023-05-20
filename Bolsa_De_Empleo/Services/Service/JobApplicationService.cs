using DataAccess.Entities;
using DataAccess;
using Services.Service.IService;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities.DataToObject;
using DataAccess.ExtensionMethods;

namespace Services.Service
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly MyDbContext _myDbContext;
        public JobApplicationService(MyDbContext dbcontext) 
        {
            _myDbContext = dbcontext;
        }

        public async Task<List<JobApplication>> GetAll()
        {
            var jobApplication = await _myDbContext.jobApplications
      .Include(c => c.Candidate)
      .Include(c => c.JobOffer)
      //.Include(c => c.JobApplication)
      .ToListAsync();

            return jobApplication;
            //List<JobApplication> Lista = await _myDbContext.jobApplications.ToListAsync();
            //List<JobApplicationVM> ListaVM = new List<JobApplicationVM>();

            //foreach (JobApplication jobApplication in Lista)
            //{
            //    JobApplicationVM newJobApplicationVM = new JobApplicationVM();
            //    newJobApplicationVM.CandidateId = jobApplication.CandidateId;
            //    newJobApplicationVM.jobOfferId = jobApplication.jobOfferId;
            //    ListaVM.Add(newJobApplicationVM);
            //}

            //return ListaVM;
        }

        public async Task<JobApplication> Create(JobApplicationVM jobApplicationVM)
        {
            JobApplication jobApplication;
            jobApplication = jobApplicationVM.toJobApplication();
            _myDbContext.jobApplications.Add(jobApplication);
            await _myDbContext.SaveChangesAsync();
            return jobApplication;
        }

        public async Task<bool> Delete(int id)
        {
            JobApplication jobApplication = await _myDbContext.jobApplications.FindAsync(id);

            if (jobApplication == null)
            {
                return false;
            }

            _myDbContext.jobApplications.Remove(jobApplication);
            await _myDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<JobApplication> Update(int id, JobApplicationVM jobApplicationVM)
        {
            JobApplication existingJobAp = await _myDbContext.jobApplications.FindAsync(id);
            if (existingJobAp == null)
            {
                return null;
            }

            existingJobAp.CandidateId = jobApplicationVM.CandidateId;
            existingJobAp.jobOfferId = jobApplicationVM.jobOfferId;

            _myDbContext.Entry(existingJobAp).State = EntityState.Modified;
            await _myDbContext.SaveChangesAsync();
            return existingJobAp;
        }


    }
}
