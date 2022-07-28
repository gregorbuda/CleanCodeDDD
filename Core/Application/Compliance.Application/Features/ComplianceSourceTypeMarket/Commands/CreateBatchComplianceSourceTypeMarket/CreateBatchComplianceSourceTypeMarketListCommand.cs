using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateBatchComplianceSourceTypeMarket
{
    public class CreateBatchComplianceSourceTypeMarketListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<CreateBatchComplianceSourceTypeMarketCommand> ComplainceSourcesTypeMarket { get; set; }
    }
}
