using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchAnReturnComplianceDistributorData
{
    /// <summary>
    /// Update Batch An Return Compliance Distributor Data List Command 
    /// </summary>
    public class UpdateBatchAnReturnComplianceDistributorDataListCommand : IRequest<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>
    {
           
        /// <summary>
        /// List Compliance Distributor Data 
        /// </summary>
        /// <value>
        /// List Compliance Distributor Data
        /// </value>
        public List<UpdateBatchAnReturnComplianceDistributorDataCommand>? ComplianceDistributorData { get; set; }
    }
}
