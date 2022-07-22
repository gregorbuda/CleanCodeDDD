using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceType.Commands.DeleteComplianceSourceType
{
    public class DeleteComplianceSourceTypeCommand : IRequest<ApiResponse<Boolean>>
    {
        [Required]
        public int ComplianceSourceTypeId { get; set; }
    }
}
