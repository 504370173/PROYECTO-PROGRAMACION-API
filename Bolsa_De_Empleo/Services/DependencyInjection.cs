using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Service;
using Services.Service.IService;

namespace Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IAcademicFormationService, AcademicFormationService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IJobOfferService, JobOfferService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<ICandidateSkillService, CandidateSkillService>();


            return services;
        }
    }
}
