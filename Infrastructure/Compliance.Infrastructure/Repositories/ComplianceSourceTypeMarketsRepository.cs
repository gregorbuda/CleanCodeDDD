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
    public class ComplianceSourceTypeMarketsRepository : RepositoryBase<ComplianceSourceTypeMarkets>, IComplianceSourceTypeMarketsRepository
    {
        public ComplianceSourceTypeMarketsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ComplianceSourceTypeMarkets>> GetByComplianceSourceTypeId(int complianceSourceTypeId)
        {
            var result =  _context.ComplianceSourceTypeMarkets
                .ToList()
                .FindAll(complianceSourceType => complianceSourceType.ComplianceSourceTypeId == complianceSourceTypeId);

            return result;
        }
    }
}
