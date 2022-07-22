using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources
{
    public class CreateComplianceSourceCommand : IRequest<ApiResponse<ComplianceSourceCreateResponse>>
    {
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
