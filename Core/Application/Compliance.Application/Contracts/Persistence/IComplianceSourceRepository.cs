using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xss.ComplianceManagementBackEnd.Entity;

namespace Compliance.Application.Contracts.Persistence
{
    public interface IComplianceSourceRepository : IAsyncRepository<ComplianceSource>
    {
    }
}
