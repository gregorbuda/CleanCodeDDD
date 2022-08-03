
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceFieldTypes.Queries
{
    /// <summary>
    /// Get Compliance Field Type Full Data List
    /// </summary>
    public class GetComplianceFieldTypeFullDataList : IRequest<ApiResponse<IReadOnlyList<ComplianceFieldTypeFullDataResponse>>>
    {

    }
}
