using Compliance.Domain.Models;


namespace Compliance.Application.Contracts.Persistence
{
    public interface IComplianceDistributorDataLogsRepository : IAsyncRepository<ComplianceDistributorDataLogs>
    {
        Task<IReadOnlyList<ComplianceDistributorDataLogs>> ItemFullDataListByDistributorId(int complianceDistributorDataId);
    }
}
