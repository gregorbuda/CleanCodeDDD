
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceType.Commands.DeleteComplianceSourceType
{
    /// <summary>
    /// Delete Compliance Source Command
    /// </summary>
    public class DeleteComplianceSourceTypeCommand : IRequest<ApiResponse<Boolean>>
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
    }
}
