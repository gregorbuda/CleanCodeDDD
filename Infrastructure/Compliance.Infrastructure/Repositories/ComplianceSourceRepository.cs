using Compliance.Application.Contracts.Persistence;
using Compliance.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xss.ComplianceManagementBackEnd.Entity;

namespace Compliance.Infrastructure.Repositories
{
    public class ComplianceSourceRepository : RepositoryBase<ComplianceSource>, IComplianceSourceRepository
    {
        public ComplianceSourceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
