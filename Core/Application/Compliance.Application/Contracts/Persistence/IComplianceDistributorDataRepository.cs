using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Contracts.Persistence
{
    public interface IComplianceDistributorDataRepository : IAsyncRepository<ComplianceDistributorData>
    {
        Task<IReadOnlyList<ComplianceDistributorData>> GetItemFullDataList();

        Task<IReadOnlyList<ComplianceDistributorData>> ItemFullDataListByDistributor(Int32 distributorId);

        Task<IReadOnlyList<ComplianceDistributorData>> UpdateBatchAnReturn(IReadOnlyList<ComplianceDistributorData> itemList);

    }
}
