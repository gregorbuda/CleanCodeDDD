
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    /// <summary>
    /// Get Compliance Source Type All List
    /// </summary>
    public class GetComplianceSourceTypeAllList : IRequest<ApiResponse<IReadOnlyList<ComplianceSourceTypesResponse>>>
    {

    }
}
