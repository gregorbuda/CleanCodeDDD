using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.DeleteComplianceFieldType
{
    /// <summary>
    /// Delete Compliance Field Type Command
    /// </summary>
    public class DeleteComplianceFieldTypeCommand : IRequest<ApiResponse<Boolean>>
    {
        /// <summary>
        /// Compliance Field Type Id
        /// </summary>
        /// <value>
        /// Compliance Field Type Id
        /// </value>
        /// <example>1</example>
        [Required]
        public Int32 ComplianceFieldTypeId { get; set; }
    }
}
