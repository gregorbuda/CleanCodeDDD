
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceFieldTypes.Queries
{
    /// <summary>
    /// Get Compliance Field Type Full Data By Id
    /// </summary>
    public class GetComplianceFieldTypeFullDataById : IRequest<ApiResponse<ComplianceFieldTypeFullDataResponse>>
    {

        /// <summary>
        /// Compliance Field Type Id
        /// </summary>
        /// <value>
        /// Compliance Field Type Id
        /// </value>
        /// <example>1</example>
        public Int32 _complianceFieldTypeId { get; set; }

        public GetComplianceFieldTypeFullDataById(Int32 ComplianceFieldTypeId)
        {
            _complianceFieldTypeId = ComplianceFieldTypeId;
        }
    }
}
