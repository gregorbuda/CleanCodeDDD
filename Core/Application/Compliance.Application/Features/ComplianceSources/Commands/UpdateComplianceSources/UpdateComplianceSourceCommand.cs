using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources
{
    public class UpdateComplianceSourceCommand : IRequest<ApiResponse<Boolean>>
    {
        [Required]
        public Int32 ComplianceSourceId { get; set; }
        [Required]
        public string ComplianceSourceName { get; set; } = string.Empty;
        [Required]
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
