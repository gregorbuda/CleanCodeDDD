using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.CreateBatchComplianceDistributorData
{
    public class CreateBatchComplianceDistributorDataListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<CreateBatchComplianceDistributorDataCommand> ComplianceDistributorData { get; set; }
    }
}
