
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Queries
{
    /// <summary>
    /// Get By ComplianceSource Type Market By Id
    /// </summary>
    public class GetByComplianceSourceTypeMarketById : IRequest<ApiResponse<IReadOnlyList<ComplianceSourceTypeMarketsResponse>>>
    {
        /// <summary>
        /// Compliance Source Type  Id
        /// </summary>
        /// <value>
        /// Compliance Source Type  Id
        /// </value>
        /// <example>1</example>
        public Int32 _complianceSourceTypeId { get; set; }

        public GetByComplianceSourceTypeMarketById(Int32 complianceSourceTypeId)
        {
            _complianceSourceTypeId = complianceSourceTypeId;
        }
    }
}
