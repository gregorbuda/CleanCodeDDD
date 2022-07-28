using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.UpdateBatchComplianceSourceTypeMarket
{
    public class UpdateBatchComplianceSourceTypeMarketListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<UpdateBatchComplianceSourceTypeMarketCommand> ComplainceSourcesTypeMarket { get; set; }
    }
}
