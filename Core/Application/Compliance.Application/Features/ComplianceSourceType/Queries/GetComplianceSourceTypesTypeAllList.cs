using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    public class GetComplianceSourceTypeAllList : IRequest<ApiResponse<IReadOnlyList<ComplianceSourceTypesResponse>>>
    {

    }
}
