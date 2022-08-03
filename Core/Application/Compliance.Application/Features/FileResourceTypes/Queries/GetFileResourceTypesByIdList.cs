
using Compliance.Domain.Models;
using MediatR;


namespace Compliance.Application.Features.FileResourceTypes.Queries
{
    /// <summary>
    /// Get File Resource Types Type By Id List
    /// </summary>
    public class GetFileResourceTypesByIdList : IRequest<ApiResponse<FileResourceType>>
    {
        /// <summary>
        /// file Resource Type Id
        /// </summary>
        /// <value>
        /// file Resource Type Id
        /// </value>
        /// <example>1</example>
        public Int32 _fileResourceTypeId { get; set; }

        public GetFileResourceTypesByIdList(Int32 FileResourceTypeId)
        {
            _fileResourceTypeId = FileResourceTypeId;
        }
    }
}
