using Compliance.Application.Contracts.Persistence;
using Compliance.Infrastructure.Persistence;
using Compliance.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IComplianceSourceRepository, ComplianceSourceRepository>();
            services.AddScoped<IInputBehaviourRepository, InputBehaviourRepository>();
            services.AddScoped<IComplianceSourceTypeMarketsRepository, ComplianceSourceTypeMarketsRepository>();
            services.AddScoped<IComplianceFieldTypeRepository, ComplianceFieldTypeRepository>();
            services.AddScoped<IComplianceSourceTypesRepository, ComplianceSourceTypesRepository>();
            services.AddScoped<IFileResourceTypeRepository, FileResourceTypeRepository>();

            return services;
        }
    }
}
