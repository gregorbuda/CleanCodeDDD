using Compliance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Contracts.Persistence
{
    public interface IComplianceSourceTypesRepository : IAsyncRepository<ComplianceSourceTypes>
    {
        Task<List<ComplianceSourceTypes>> GetComplianceSourceTypeByCompianceSourceId(Int32 CompianceSourceId);

        Task<IReadOnlyList<ComplianceSourceTypes>> GetItemFullDataList();

        Task<ComplianceSourceTypes> GetFullDataById(Int32 ComplianceFieldTypeId);

        Task<Boolean> UpdateBatch(IEnumerable<ComplianceSourceTypes> itemList);
    }
}
