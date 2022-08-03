
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.FileResourceTypes.Queries
{
    /// <summary>
    /// Get File Resource Types All List
    /// </summary>
    public class GetFileResourceTypesAllList : IRequest<ApiResponse<IReadOnlyList<FileResourceTypeResponse>>>
    {
    }
}
