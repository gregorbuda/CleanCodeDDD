
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceFieldTypes.Queries
{
    /// <summary>
    /// Get Compliance Field Type By Id List
    /// </summary>
    public class GetComplianceFieldTypeByIdList : IRequest<ApiResponse<ComplianceFieldType>>
    {

        /// <summary>
        /// Compliance Field Type Id
        /// </summary>
        /// <value>
        /// Compliance Field Type Id
        /// </value>
        /// <example>1</example>
        public Int32 _complianceFieldTypeId { get; set; }

        public GetComplianceFieldTypeByIdList(Int32 ComplianceFieldTypeId)
        {
            _complianceFieldTypeId = ComplianceFieldTypeId;
        }
    }
}
