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
    public class GetByComplianceSourceTypeMarketById : IRequest<ApiResponse<IReadOnlyList<ComplianceSourceTypeMarketsResponse>>>
    {
        public Int32 _complianceSourceTypeId { get; set; }

        public GetByComplianceSourceTypeMarketById(Int32 complianceSourceTypeId)
        {
            _complianceSourceTypeId = complianceSourceTypeId;
        }
    }
}
