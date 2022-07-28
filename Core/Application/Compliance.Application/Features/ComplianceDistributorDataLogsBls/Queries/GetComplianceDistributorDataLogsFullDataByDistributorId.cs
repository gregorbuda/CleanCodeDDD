using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorDataLogsBls.Queries
{
    public class GetComplianceDistributorDataLogsFullDataByDistributorId : IRequest<ApiResponse<IReadOnlyList<ComplianceDistributorDataLogsResponse>>>
    {
        public Int32 _complianceDistributorDataId { get; set; }

        public GetComplianceDistributorDataLogsFullDataByDistributorId(Int32 complianceDistributorDataId)
        {
            _complianceDistributorDataId = complianceDistributorDataId;
        }
    }
}
