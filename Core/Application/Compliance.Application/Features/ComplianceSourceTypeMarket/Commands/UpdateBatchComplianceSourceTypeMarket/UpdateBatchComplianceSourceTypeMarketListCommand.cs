using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.UpdateBatchComplianceSourceTypeMarket
{
    /// <summary>
    /// Update Batch Compliance Source Type Market List Command
    /// </summary>
    public class UpdateBatchComplianceSourceTypeMarketListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Complaince Sources Type Market
        /// </summary>
        /// <value>
        /// List Complaince Sources Type Market
        /// </value>
        public List<UpdateBatchComplianceSourceTypeMarketCommand> ComplainceSourcesTypeMarket { get; set; }
    }
}
