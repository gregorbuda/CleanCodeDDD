
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSources.Queries
{
    /// <summary>
    /// Get Compliance Source All List
    /// </summary>
    public class GetComplianceSourceByIdList : IRequest<ApiResponse<ComplianceSourceResponse>>
    {
        /// <summary>
        /// Compliance Source Id
        /// </summary>
        /// <value>
        /// Compliance Source Id
        /// </value>
        /// <example>1</example>
        public Int32 _complianceSourceId { get; set; }

        public GetComplianceSourceByIdList(Int32 ComplianceSourceId)
        {
            _complianceSourceId = ComplianceSourceId;
        }
    }
}
