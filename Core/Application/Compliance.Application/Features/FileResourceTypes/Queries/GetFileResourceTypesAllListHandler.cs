using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.FileResourceTypes.Queries
{
    public class GetFileResourceTypesAllListHandler : IRequestHandler<GetFileResourceTypesAllList, ApiResponse<IReadOnlyList<FileResourceTypeResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFileResourceTypesAllListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<FileResourceTypeResponse>>> Handle(GetFileResourceTypesAllList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<FileResourceType> fileResourceType = null;
            IReadOnlyList<FileResourceTypeResponse> fileResourceTypeResponse = null;
            String CodeResult = "";

            try
            {
                fileResourceType = await _unitOfWork.fileResourceTypeRepository.GetAllAsync();

                fileResourceTypeResponse = _mapper.Map<IReadOnlyList<FileResourceTypeResponse>>(fileResourceType);

                if (fileResourceType.Count > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "File Resource Not Found";
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

            ApiResponse<IReadOnlyList<FileResourceTypeResponse>> response = new ApiResponse<IReadOnlyList<FileResourceTypeResponse>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = fileResourceTypeResponse,
                Success = success
            };

            return response;
        }
    }
}
