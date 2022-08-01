using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    public class GetComplianceSourceTypesIdFullDataList : IRequest<ApiResponse<IReadOnlyList<ComplianceSourceTypesFullDataResponse>>>
    {
    }
}
