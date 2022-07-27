using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Infrastructure.Repositories
{
    public class ComplianceSourceTypesRepository : RepositoryBase<ComplianceSourceTypes>, IComplianceSourceTypesRepository
    {
        public ComplianceSourceTypesRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<ComplianceSourceTypes>> GetComplianceSourceTypeByCompianceSourceId(Int32 ComplianceSourceId)
        {
            return await _context.ComplianceSourceTypes!.Where(v => v.ComplianceSourceId == ComplianceSourceId).ToListAsync();
        }


        public async Task<IReadOnlyList<ComplianceSourceTypes>> GetItemFullDataList()
        {
            var result = await _context.ComplianceSourceTypes
                  .Include(complianceSourceType => complianceSourceType.ComplianceSource)
                  .Include(compliancesourceType => compliancesourceType.ComplianceFieldType.InputBehaviour)
                  .Include(complianceSourceType => complianceSourceType.ComplianceSourceTypeMarkets)
                  .Where(complianceSourceType => complianceSourceType.Status != 2)
                  .ToListAsync();

            return result;
        }

        public async Task<ComplianceSourceTypes> GetFullDataById(Int32 ComplianceSourceTypesId)
        {
            var result = await _context.ComplianceSourceTypes
                .Include(complianceSourceType => complianceSourceType.ComplianceSource)
                .Include(complianceSourceType => complianceSourceType.ComplianceFieldType)
                .Include(complianceSourceType => complianceSourceType.ComplianceSourceTypeMarkets)
                .Where(complianceSourceType => complianceSourceType.ComplianceSourceTypeId == ComplianceSourceTypesId)
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
