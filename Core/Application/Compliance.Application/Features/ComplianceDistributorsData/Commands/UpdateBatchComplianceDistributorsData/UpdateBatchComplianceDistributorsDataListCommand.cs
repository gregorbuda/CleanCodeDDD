using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchComplianceDistributorsData
{
    public class UpdateBatchComplianceDistributorsDataListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<UpdateBatchComplianceDistributorsDataCommand> ComplianceDistributorData { get; set; }
    }
}
