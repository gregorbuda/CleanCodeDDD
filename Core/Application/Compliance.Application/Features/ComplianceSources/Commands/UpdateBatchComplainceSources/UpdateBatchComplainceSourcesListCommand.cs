using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSources.Commands.UpdateBatchComplainceSources
{
    /// <summary>
    /// Update Batch Compliance Source List Command
    /// </summary>
    public class UpdateBatchComplainceSourcesListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Compliance Source
        /// </summary>
        /// <value>
        /// List Compliance Source
        /// </value>
        public List<UpdateBatchComplainceSourcesCommand> ComplainceSourcesList { get; set; }
    }
}
