using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Queries
{
    public class GetComplianceSourceTypeMarketById : IRequest<ApiResponse<ComplianceSourceTypeMarketsResponse>>
    {
        public Int32 _complianceSourceTypeMarketId { get; set; }

        public GetComplianceSourceTypeMarketById(Int32 complianceSourceTypeMarketId)
        {
            _complianceSourceTypeMarketId = complianceSourceTypeMarketId;
        }
    }
}
