using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSources.Queries
{
    /// <summary>
    /// Get Compliance Source All List
    /// </summary>
    public class GetComplianceSourceAllList : IRequest<ApiResponse<IReadOnlyList<ComplianceSource>>>
    {

    }
}
