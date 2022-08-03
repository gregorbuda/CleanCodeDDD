using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchComplianceDistributorsData
{
    /// <summary>
    /// Update Batch  Compliance Distributor Data List Command
    /// </summary>
    public class UpdateBatchComplianceDistributorsDataListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Compliance Distributor Data
        /// </summary>
        /// <value>
        /// List Compliance Distributor Data
        /// </value>
        public List<UpdateBatchComplianceDistributorsDataCommand>? ComplianceDistributorData { get; set; }
    }
}
