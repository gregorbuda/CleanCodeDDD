using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceFieldTypes.Queries
{
    public class GetComplianceFieldTypeFullDataById : IRequest<ApiResponse<IReadOnlyList<ComplianceFieldTypeFullDataResponse>>>
    {
        public Int32 _complianceFieldTypeId { get; set; }

        public GetComplianceFieldTypeFullDataById(Int32 ComplianceFieldTypeId)
        {
            _complianceFieldTypeId = ComplianceFieldTypeId;
        }
    }
}
