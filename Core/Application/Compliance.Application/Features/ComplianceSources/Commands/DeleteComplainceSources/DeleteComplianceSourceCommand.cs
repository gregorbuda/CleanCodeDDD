using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Compliance.Application.Features.ComplianceSources.Commands.DeleteComplianceSources
{
    /// <summary>
    /// Delete Compliance Source Command
    /// </summary>
    public class DeleteComplianceSourceCommand : IRequest<ApiResponse<Boolean>>
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
    }
}
