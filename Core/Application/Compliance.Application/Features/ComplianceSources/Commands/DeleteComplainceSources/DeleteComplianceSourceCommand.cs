using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSources.Commands.DeleteComplianceSources
{
    public class DeleteComplianceSourceCommand : IRequest<ApiResponse<Boolean>>
    {
        [Required]
        public Int32 ComplianceSourceId { get; set; }
    }
}
