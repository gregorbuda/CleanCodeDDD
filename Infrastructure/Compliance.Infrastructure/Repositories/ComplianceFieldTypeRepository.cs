using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using Compliance.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Infrastructure.Repositories
{
    public class ComplianceFieldTypeRepository : RepositoryBase<ComplianceFieldType>, IComplianceFieldTypeRepository
    {
        public ComplianceFieldTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
