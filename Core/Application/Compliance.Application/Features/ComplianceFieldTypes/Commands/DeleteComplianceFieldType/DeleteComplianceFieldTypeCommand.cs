using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.DeleteComplianceFieldType
{
    public class DeleteComplianceFieldTypeCommand : IRequest<ApiResponse<Boolean>>
    {
        [Required]
        public Int32 ComplianceFieldTypeId { get; set; }
    }
}
