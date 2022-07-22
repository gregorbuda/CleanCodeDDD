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
    public class GetFileResourceTypesByIdListHandler : IRequestHandler<GetFileResourceTypesByIdList, ApiResponse<FileResourceTypeResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFileResourceTypesByIdListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<FileResourceTypeResponse>> Handle(GetFileResourceTypesByIdList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            FileResourceType fileResourceType = null;
            FileResourceTypeResponse fileResourceTypeResponse = null;
            String CodeResult = "";

            try
            {
                fileResourceType = await _unitOfWork.fileResourceTypeRepository.GetByIdAsync(request._fileResourceTypeId);

                fileResourceTypeResponse = _mapper.Map<FileResourceTypeResponse>(fileResourceType);

                if (fileResourceType.FileResourceTypeId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "File Resource Type Not Found";
                    fileResourceTypeResponse = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                fileResourceTypeResponse = null;
                success = false;
            }

            ApiResponse<FileResourceTypeResponse> response = new ApiResponse<FileResourceTypeResponse>
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
