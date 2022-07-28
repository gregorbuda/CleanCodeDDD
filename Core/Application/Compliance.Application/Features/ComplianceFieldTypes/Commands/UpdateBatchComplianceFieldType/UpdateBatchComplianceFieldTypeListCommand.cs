using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateBatchComplianceFieldType
{
    public class UpdateBatchComplianceFieldTypeListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<UpdateBatchComplianceFieldTypeCommand> ComplainceFieldTypeList { get; set; }
    }
}
