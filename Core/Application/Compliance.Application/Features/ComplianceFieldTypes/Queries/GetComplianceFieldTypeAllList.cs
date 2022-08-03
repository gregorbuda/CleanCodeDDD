using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceFieldTypes.Queries
{
    /// <summary>
    /// Get Compliance Field Type All List
    /// </summary>
    public class GetComplianceFieldTypeAllList : IRequest<ApiResponse<IReadOnlyList<ComplianceFieldType>>>
    {
    }
}
