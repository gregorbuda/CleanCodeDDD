using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateBatchComplianceSourceTypeMarket
{
    /// <summary>
    /// Create Batch Compliance Source Type Market List Command Handler
    /// </summary>
    public class CreateBatchComplianceSourceTypeMarketListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Complaince Sources Type Market
        /// </summary>
        /// <value>
        /// List Complaince Sources Type Market
        /// </value>
        public List<CreateBatchComplianceSourceTypeMarketCommand> ComplainceSourcesTypeMarket { get; set; }
    }
}
