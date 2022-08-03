using Compliance.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Compliance.Application.Features.ComplianceDistributorsData.Queries
{
    /// <summary>
    /// Get Compliance Distributor Data Full Data By DistributorI d
    /// </summary>
    public class GetComplianceDistributorDataFullDataByDistributorId : IRequest<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>
    {
        /// <summary>
        /// Compliance Distributor Data Id
        /// </summary>
        /// <value>
        /// Compliance Distributor Data Id
        /// </value>
        /// <example>2</example>
        [Required]
        public Int32 _complianceDistributorDataId { get; set; }

        public GetComplianceDistributorDataFullDataByDistributorId(Int32 complianceDistributorDataId)
        {
            _complianceDistributorDataId = complianceDistributorDataId;
        }
    }
}
