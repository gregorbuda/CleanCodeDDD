using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Compliance.Application.Features.FileResourceTypes.Queries
{
    /// <summary>
    /// Get File Resource Types Type By Id List Hanlder
    /// </summary>
    public class GetFileResourceTypesByIdListHandler : IRequestHandler<GetFileResourceTypesByIdList, ApiResponse<FileResourceType>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFileResourceTypesByIdListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<FileResourceType>> Handle(GetFileResourceTypesByIdList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            FileResourceType fileResourceType = null;
            FileResourceTypeResponse? fileResourceTypeResponse = null;
            String CodeResult = "";

            try
            {
                fileResourceType = await _unitOfWork.fileResourceTypeRepository.GetByIdAsync(request._fileResourceTypeId);

               // fileResourceTypeResponse = _mapper.Map<FileResourceTypeResponse>(fileResourceType);

                if (fileResourceType != null)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"File Resource Type Id {request._fileResourceTypeId} Not Found";
                    fileResourceType = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                fileResourceType = null;
                success = false;
            }

            ApiResponse<FileResourceType> response = new ApiResponse<FileResourceType>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = fileResourceType,
                Success = success
            };

            return response;
        }
    }
}
