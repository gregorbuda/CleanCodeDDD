using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.InputBehaviours.Commands.UpdateBatchInputBehaviours
{
    /// <summary>
    /// Update Batch Input Behaviours Command Handler
    /// </summary>
    public class UpdateBatchInputBehavioursListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Complaince Sources
        /// </summary>
        /// <value>
        /// List Complaince Sources
        /// </value>
        public List<UpdateBatchInputBehavioursCommand>? ComplainceSourcesList { get; set; }
    }
}
