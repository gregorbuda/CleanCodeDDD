using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateBatchComplianceFieldType
{
    /// <summary>
    /// Update Compliance Field Type List Command 
    /// </summary>
    public class UpdateBatchComplianceFieldTypeListCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// List Complaince Field Type 
        /// </summary>
        /// <value>
        /// List Complaince Field Type
        /// </value>
        public List<UpdateBatchComplianceFieldTypeCommand> ComplainceFieldTypeList { get; set; }
    }
}
