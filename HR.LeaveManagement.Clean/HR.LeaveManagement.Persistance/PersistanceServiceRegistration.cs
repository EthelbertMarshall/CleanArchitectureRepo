using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistance.DatabaseContext;
using HR.LeaveManagement.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HR.LeaveManagement.Persistance
{
    public static class PersistanceServiceRegistration
    {

        public static IServiceCollection AddPersistanceServies(this IServiceCollection services , 
            IConfiguration configuration)
        {
            services.AddDbContext<HRDatabaseContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("HRDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();

            return services;
        }
    }
}
