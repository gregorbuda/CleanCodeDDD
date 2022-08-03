
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    /// <summary>
    /// Get Compliance Source Type By Id List
    /// </summary>
    public class GetComplianceSourceTypeByIdList : IRequest<ApiResponse<ComplianceSourceTypes>>
    {
        /// <summary>
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>2</example>
        public Int32 _complianceSourceTypeId { get; set; }

        public GetComplianceSourceTypeByIdList(Int32 ComplianceSourceTypeId)
        {
            _complianceSourceTypeId = ComplianceSourceTypeId;
        }
    }
}
