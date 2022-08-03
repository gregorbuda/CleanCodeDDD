using Compliance.Domain.Models;
using MediatR;

using System.ComponentModel.DataAnnotations;


namespace Compliance.Application.Features.ComplianceSourceType.Commands.UpdateComplianceSourceType
{
    /// <summary>
    /// Update Batch Compliance Source Command
    /// </summary>
    public class UpdateComplianceSourceTypeCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>2</example>
        [Required]
        public int ComplianceSourceTypeId { get; set; }
        /// <summary>
        /// Compliance Source Id
        /// </summary>
        /// <value>
        /// Compliance Source Id
        /// </value>
        /// <example>2</example>
        [Required]
        public int ComplianceSourceId { get; set; }
        /// <summary>
        /// Compliance Field Type Id
        /// </summary>
        /// <value>
        /// Compliance Field Type Id
        /// </value>
        /// <example>2</example>
        [Required]
        public int ComplianceFieldTypeId { get; set; }
        /// <summary>
        /// Distributor Id
        /// </summary>
        /// <value>
        /// Distributor Id
        /// </value>
        /// <example>2</example>
        [Required]
        public int DistributorId { get; set; }
        /// <summary>
        /// Requires Compliance
        /// </summary>
        /// <value>
        /// Requires Compliance
        /// </value>
        /// <example>true</example>
        [Required]
        public bool RequiresCompliance { get; set; }
        /// <summary>
        /// Compliance File Size Kb
        /// </summary>
        /// <value>
        /// Compliance File Size Kb
        /// </value>
        /// <example>10</example>
        [Required]
        public int? ComplianceFileSizeKb { get; set; }
        /// <summary>
        /// HeightPx
        /// </summary>
        /// <value>
        /// HeightPx
        /// </value>
        /// <example>10</example>
        public short? HeightPx { get; set; }
        /// <summary>
        /// WidthPx
        /// </summary>
        /// <value>
        /// WidthPx
        /// </value>
        /// <example>10</example>
        public short? WidthPx { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        /// <value>
        /// Status
        /// </value>
        /// <example>1</example>
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
