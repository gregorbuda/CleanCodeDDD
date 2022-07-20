using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xss.ComplianceManagementBackEnd.Entity;

namespace Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources
{
    public class CreateComplianceSourceCommand : IRequest<ApiResponse<Int32>>
    {
        public int ComplianceSourceId { get; set; }
        public string ComplianceSourceName { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
