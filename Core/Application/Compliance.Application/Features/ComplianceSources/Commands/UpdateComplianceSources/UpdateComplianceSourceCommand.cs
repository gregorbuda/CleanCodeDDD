using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources
{
    /// <summary>
    /// Update Batch Compliance Source Command
    /// </summary>
    public class UpdateComplianceSourceCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// Compliance Source Id
        /// </summary>
        /// <value>
        /// Compliance Source Id
        /// </value>
        /// <example>1</example>
        [Required]
        public Int32 ComplianceSourceId { get; set; }
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
        /// <example>1</example>
        [Required]
        public byte Status { get; set; }
        /// <summary>
        /// CreatedDate
        /// </summary>
        /// <value>
        /// CreatedDate
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
