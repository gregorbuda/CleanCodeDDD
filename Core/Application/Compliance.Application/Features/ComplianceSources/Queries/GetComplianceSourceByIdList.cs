using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSources.Queries
{
    public class GetComplianceSourceByIdList : IRequest<ApiResponse<ComplianceSourceResponse>>
    {
        public Int32 _complianceSourceId { get; set; }

        public GetComplianceSourceByIdList(Int32 ComplianceSourceId)
        {
            _complianceSourceId = ComplianceSourceId;
        }
    }
}
