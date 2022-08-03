using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.FileResourceTypes.Commands.CreateFileResourceTypes
{
    /// <summary>
    /// Create File Resource Types Command Hanlder
    /// </summary>
    public class CreateFileResourceTypesCommandHandler : IRequestHandler<CreateFileResourceTypesCommand, ApiResponse<FileResourceTypeCreateResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFileResourceTypesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<FileResourceTypeCreateResponse>> Handle(CreateFileResourceTypesCommand request, CancellationToken cancellationToken)
        {
            var fileResourceTypeEntity = _mapper.Map<FileResourceType>(request);

            FileResourceType fileResourceType = null;
            FileResourceTypeCreateResponse objReponse = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                fileResourceType = await _unitOfWork.fileResourceTypeRepository.AddAsync(fileResourceTypeEntity);

                objReponse = _mapper.Map<FileResourceTypeCreateResponse>(fileResourceType);

                if (fileResourceType.FileResourceTypeId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "No se pudo registrar el ComplianceSource";
                    fileResourceType = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                success = false;
                fileResourceType = null;
            }

            ApiResponse<FileResourceTypeCreateResponse> response = new ApiResponse<FileResourceTypeCreateResponse>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = objReponse,
                Success = success
            };

            return response;
        }
    }
}
