using Compliance.Application.Responses;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceType.Commands.UpdateBatchComplianceSourceType
{
    public class UpdateBatchComplianceSourceTypeListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<UpdateBatchComplianceSourceTypeCommand> ComplainceSourcesType{ get; set; }
    }
}
