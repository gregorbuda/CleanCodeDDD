
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    /// <summary>
    /// Get Compliance Source Type Full Data Data List
    /// </summary>
    public class GetComplianceSourceTypesIdFullDataList : IRequest<ApiResponse<IReadOnlyList<ComplianceSourceTypesFullDataResponse>>>
    {
    }
}
