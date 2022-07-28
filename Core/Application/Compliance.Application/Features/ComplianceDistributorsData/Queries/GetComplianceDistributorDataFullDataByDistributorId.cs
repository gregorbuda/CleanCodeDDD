﻿using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.ComplianceDistributorsData.Queries
{
    public class GetComplianceDistributorDataFullDataByDistributorId : IRequest<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>
    {
        public Int32 _complianceDistributorDataId { get; set; }

        public GetComplianceDistributorDataFullDataByDistributorId(Int32 complianceDistributorDataId)
        {
            _complianceDistributorDataId = complianceDistributorDataId;
        }
    }
}
