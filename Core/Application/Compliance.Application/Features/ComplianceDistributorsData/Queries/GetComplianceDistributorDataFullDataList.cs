﻿using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceDistributorsData.Queries
{
    public class GetComplianceDistributorDataFullDataList : IRequest<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>
    {

    }
}
