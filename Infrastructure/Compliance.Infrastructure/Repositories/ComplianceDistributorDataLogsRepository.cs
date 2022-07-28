using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Persistence;


namespace Compliance.Infrastructure.Repositories
{
    public class ComplianceDistributorDataLogsRepository : RepositoryBase<ComplianceDistributorDataLogs>, IComplianceDistributorDataLogsRepository
    {
        public ComplianceDistributorDataLogsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
