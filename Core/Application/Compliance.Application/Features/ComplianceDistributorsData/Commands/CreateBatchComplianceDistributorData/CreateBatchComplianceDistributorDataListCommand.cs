using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.CreateBatchComplianceDistributorData
{
    /// <summary>
    /// Create Batch Compliance Distributor Data List Command
    /// </summary>
    public class CreateBatchComplianceDistributorDataListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// Compliance Distributor Data
        /// </summary>
        /// <value>
        /// Compliance Distributor Data
        /// </value>
        public List<CreateBatchComplianceDistributorDataCommand>? ComplianceDistributorData { get; set; }
    }
}
