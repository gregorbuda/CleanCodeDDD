using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    public class GetComplianceSourceTypesIdFullDataList : IRequest<ApiResponse<IReadOnlyList<ComplianceSourceTypesFullDataResponse>>>
    {
    }
}
