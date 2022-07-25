using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceType.Commands.CreateComplianceSourceType
{
    public class CreateComplianceSourceTypeCommand : IRequest<ApiResponse<ComplianceSourceTypeCreateResponse>>
    {
        [Required]
        public int ComplianceFieldTypeId { get; set; }
        [Required]
        public int ComplianceSourceId { get; set; }
        [Required]
        public int DistributorId { get; set; }
        [Required]
        public bool RequiresCompliance { get; set; }
        [Required]
        public int? ComplianceFileSizeKb { get; set; }
        [Required]
        public short? HeightPx { get; set; }
        public short? WidthPx { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
