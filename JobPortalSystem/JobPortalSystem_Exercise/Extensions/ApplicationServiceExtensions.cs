using JobPortalSystem_Exercise.Data.Repository;
using JobPortalSystem_Exercise.Helpers;
using JobPortalSystem_Exercise.Interface;
using JobPortalSystem_Exercise.Models;
using JobPortalSystem_Exercise.Services;
using Microsoft.EntityFrameworkCore;

namespace JobPortalSystem_Exercise.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IPublicService, PublicService>();
            services.AddScoped<IPublicRepository, PublicRepository>();
            services.AddScoped<IJobProviderService, JobProviderService>();
            services.AddScoped<IJobProviderRepository, JobProviderRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<JobPortalExDbContext>(options => 
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddDbContext<JobPortalExDbContext>();

            return services;
        }
    }
}
