using Compliance.Application.Responses;
using MediatR;

namespace Compliance.Application.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls
{
    public class CreateBatchComplianceDistributorDataLogsBlsListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<CreateBatchComplianceDistributorDataLogsBlsCommand> complianceDistributorDataLogs { get; set; }
    }
}
