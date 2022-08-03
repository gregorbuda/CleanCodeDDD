
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    /// <summary>
    /// Get Compliance Source Type Full Data By Id
    /// </summary>
    public class GetComplianceSourceTypeFullDataById : IRequest<ApiResponse<ComplianceSourceTypesFullDataResponse>>
    {
        /// <summary>
        /// Compliance Source Type Id
        /// </summary>
        /// <value>
        /// Compliance Source Type Id
        /// </value>
        /// <example>2</example>
        public Int32 _complianceSourceTypeId { get; set; }

        public GetComplianceSourceTypeFullDataById(Int32 ComplianceSourceTypeId)
        {
            _complianceSourceTypeId = ComplianceSourceTypeId;
        }
    }
}
