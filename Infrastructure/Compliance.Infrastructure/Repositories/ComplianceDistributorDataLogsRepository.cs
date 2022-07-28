using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Compliance.Infrastructure.Repositories
{
    public class ComplianceDistributorDataLogsRepository : RepositoryBase<ComplianceDistributorDataLogs>, IComplianceDistributorDataLogsRepository
    {
        public ComplianceDistributorDataLogsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ComplianceDistributorDataLogs>> ItemFullDataListByDistributorId(int complianceDistributorDataId)
        {
            var result = await _context.ComplianceDistributorDataLogs
                .Include(log => log.ComplianceDistributorData)
                .Where(log => log.ComplianceDistributorDataId == complianceDistributorDataId)
                .ToListAsync();

            return result;
        }
    }
}
