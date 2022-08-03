using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceSourceType.Commands.UpdateBatchComplianceSourceType
{
    /// <summary>
    /// Update Batch Compliance Source Type List Command
    /// </summary>
    public class UpdateBatchComplianceSourceTypeListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Compliance Source Type 
        /// </summary>
        /// <value>
        /// list Compliance Source Type 
        /// </value>
        public List<UpdateBatchComplianceSourceTypeCommand> ComplainceSourcesType{ get; set; }
    }
}
