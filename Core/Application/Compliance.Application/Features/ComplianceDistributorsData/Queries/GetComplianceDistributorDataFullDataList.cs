using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceDistributorsData.Queries
{
    /// <summary>
    /// Get Compliance Distributor Data Full Data List
    /// </summary>
    public class GetComplianceDistributorDataFullDataList : IRequest<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>
    {

    }
}
