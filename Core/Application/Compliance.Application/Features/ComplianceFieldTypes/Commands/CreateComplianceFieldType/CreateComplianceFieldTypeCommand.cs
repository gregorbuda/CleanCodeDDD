using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.CreateComplianceFieldType
{
    public class CreateComplianceFieldTypeCommand : IRequest<ApiResponse<ComplianceFieldTypeCreateResponse>>
    {
        [Required]
        public string ComplianceFieldTypeName { get; set; } = string.Empty;
        [Required]
        public string TranslationKey { get; set; } = string.Empty;
        [Required]
        public string FieldPath { get; set; } = string.Empty;
        [Required]
        public int? ComplianceFileSizeKb { get; set; }
        [Required]
        public short? HeightPx { get; set; }
        [Required]
        public short? WidthPx { get; set; }
        [Required]
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
