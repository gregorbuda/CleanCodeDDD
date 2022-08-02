using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.FileResourceTypes.Queries
{
    public class GetFileResourceTypesByIdList : IRequest<ApiResponse<FileResourceType>>
    {
        public Int32 _fileResourceTypeId { get; set; }

        public GetFileResourceTypesByIdList(Int32 FileResourceTypeId)
        {
            _fileResourceTypeId = FileResourceTypeId;
        }
    }
}
