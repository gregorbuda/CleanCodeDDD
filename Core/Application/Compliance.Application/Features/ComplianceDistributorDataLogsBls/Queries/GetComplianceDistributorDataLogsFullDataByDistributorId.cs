using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorDataLogsBls.Queries
{
    /// <summary>
    /// Get Compliance Distributor Data Logs Full Data By Distributor Id
    /// </summary>
    public class GetComplianceDistributorDataLogsFullDataByDistributorId : IRequest<ApiResponse<IReadOnlyList<ComplianceDistributorDataLogsResponse>>>
    {
        /// <summary>
        /// Compliance Distributor Data Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data Id
        /// </value>
        /// <example>2</example>
        public Int32 _complianceDistributorDataId { get; set; }

        public GetComplianceDistributorDataLogsFullDataByDistributorId(Int32 complianceDistributorDataId)
        {
            _complianceDistributorDataId = complianceDistributorDataId;
        }
    }
}
