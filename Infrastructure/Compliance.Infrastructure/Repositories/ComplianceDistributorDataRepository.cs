using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Compliance.Infrastructure.Repositories
{
    public class ComplianceDistributorDataRepository : RepositoryBase<ComplianceDistributorData>, IComplianceDistributorDataRepository
    {
        public ComplianceDistributorDataRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ComplianceDistributorData>> GetItemFullDataList()
        {
            var result = await _context.ComplianceDistributorData
                .Include(complianceDistributor => complianceDistributor.ComplianceSourceType.ComplianceFieldType.InputBehaviour)
                .Include(complianceDistributor => complianceDistributor.ComplianceSourceType.ComplianceSource)
                .ToListAsync();

            return result;
        }

        public async Task<IReadOnlyList<ComplianceDistributorData>> ItemFullDataListByDistributor(int distributorId)
        {
            var result = await _context.ComplianceDistributorData
                .Where(complianceDistributor => complianceDistributor.DistributorId == distributorId)
                .Include(complianceDistributor => complianceDistributor.ComplianceSourceType.ComplianceFieldType.InputBehaviour)
                .Include(complianceDistributor => complianceDistributor.ComplianceDistributorDataLogs)
                .ToListAsync();

            return result;
        }


        public Task<IReadOnlyList<ComplianceDistributorData>> UpdateBatchAnReturn(IReadOnlyList<ComplianceDistributorData> itemList)
        {
            _context.ChangeTracker.Clear();

            _context.UpdateRange(itemList);

            _context.SaveChanges();

            return (Task<IReadOnlyList<ComplianceDistributorData>>)itemList;
        }
    }
}
