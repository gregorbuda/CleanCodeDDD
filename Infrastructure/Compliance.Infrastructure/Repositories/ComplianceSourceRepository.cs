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
    public class ComplianceSourceRepository : RepositoryBase<ComplianceSource>, IComplianceSourceRepository
    {
        public ComplianceSourceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ComplianceSource> GetById(int ComplianceSourceId)
        {
            var complianceSource = await _context.ComplianceSource.Where(x => x.ComplianceSourceId == ComplianceSourceId).FirstOrDefaultAsync();

            return complianceSource;
        }
    }
}
