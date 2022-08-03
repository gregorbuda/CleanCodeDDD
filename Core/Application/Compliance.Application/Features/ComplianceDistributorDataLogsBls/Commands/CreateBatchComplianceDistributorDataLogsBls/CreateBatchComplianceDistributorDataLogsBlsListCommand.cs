using Compliance.Domain.Models;
using MediatR;

namespace Compliance.Application.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls
{
    /// <summary>
    /// Create Batch Compliance Distributor Data Logs Bls List Command
    /// </summary>
    public class CreateBatchComplianceDistributorDataLogsBlsListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Create Batch Compliance Distributor Data Logs Bls Command
        /// </summary>
        /// <value>
        /// List Create Batch Compliance Distributor Data Logs Bls Command
        /// </value>
        public List<CreateBatchComplianceDistributorDataLogsBlsCommand>? complianceDistributorDataLogs { get; set; }
    }
}
