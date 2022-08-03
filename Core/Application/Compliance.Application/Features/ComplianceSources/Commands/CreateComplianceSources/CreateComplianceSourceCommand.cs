using Compliance.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources
{
    /// <summary>
    /// Create Compliance Source Command
    /// </summary>
    public class CreateComplianceSourceCommand : IRequest<ApiResponse<ComplianceSourceCreateResponse>>
    {
        /// <summary>
        /// Compliance Source Name
        /// </summary>
        /// <value>
        /// Compliance Source Name
        /// </value>
        /// <example>Test Name</example>
        [Required]
        public string ComplianceSourceName { get; set; } = string.Empty;
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1/example>
        [Required]
        public byte Status { get; set; }
        /// <summary>
        /// Created Date
        /// </summary>
        /// <value>
        /// Created Date
        /// </value>
        /// <example>2022-11-10</example>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// CreatedBy
        /// </summary>
        /// <value>
        /// CreatedBy
        /// </value>
        /// <example>1</example>
        public int CreatedBy { get; set; }
        /// <summary>
        /// UpdatedDate
        /// </summary>
        /// <value>
        /// UpdatedDate
        /// </value>
        /// <example>2022-11-10</example>
        public DateTime? UpdatedDate { get; set; }
        /// <summary>
        /// UpdatedBy
        /// </summary>
        /// <value>
        /// UpdatedBy
        /// </value>
        /// <example>1</example>
        public int? UpdatedBy { get; set; }

    }
}
