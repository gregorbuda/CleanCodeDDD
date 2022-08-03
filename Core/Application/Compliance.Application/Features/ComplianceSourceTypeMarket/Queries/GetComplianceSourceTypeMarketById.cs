using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Queries
{
    /// <summary>
    /// Get  ComplianceSource Type Market By Id
    /// </summary>
    public class GetComplianceSourceTypeMarketById : IRequest<ApiResponse<ComplianceSourceTypeMarketsResponse>>
    {
        /// <summary>
        /// Compliance Source Type Market Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Market Id
        /// </value>
        /// <example>1</example>
        public Int32 _complianceSourceTypeMarketId { get; set; }

        public GetComplianceSourceTypeMarketById(Int32 complianceSourceTypeMarketId)
        {
            _complianceSourceTypeMarketId = complianceSourceTypeMarketId;
        }
    }
}
