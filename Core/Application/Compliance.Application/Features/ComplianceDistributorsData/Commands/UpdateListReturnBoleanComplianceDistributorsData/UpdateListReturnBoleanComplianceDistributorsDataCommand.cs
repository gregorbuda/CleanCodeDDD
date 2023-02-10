using Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchComplianceDistributorsData;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Application.Features.ComplianceDistributorsData.Commands.UpdateListReturnBoleanComplianceDistributorsData
{
    public class UpdateListReturnBoleanComplianceDistributorsDataListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Compliance Distributor Data
        /// </summary>
        /// <value>
        /// List Compliance Distributor Data
        /// </value>
        public List<UpdateListReturnBoleanComplianceDistributorsDataCommand>? ComplianceDistributorData { get; set; }
    }
}
