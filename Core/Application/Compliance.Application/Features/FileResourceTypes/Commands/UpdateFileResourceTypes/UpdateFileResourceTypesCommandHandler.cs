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

namespace Compliance.Application.Features.FileResourceTypes.Commands.UpdateFileResourceTypes
{
    public class UpdateFileResourceTypesCommandHandler : IRequestHandler<UpdateFileResourceTypesCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFileResourceTypesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(UpdateFileResourceTypesCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var FileResourceTypeToUpdate = await _unitOfWork.fileResourceTypeRepository.GetByIdAsync(request.FileResourceTypeId);

                if (FileResourceTypeToUpdate != null)
                {
                    _mapper.Map(request, FileResourceTypeToUpdate, typeof(UpdateFileResourceTypesCommand), typeof(FileResourceType));

                    _unitOfWork.fileResourceTypeRepository.UpdateEntity(FileResourceTypeToUpdate);

                    await _unitOfWork.Complete();

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "File Resource Type Not Found";
                    Result = false;
                    success = false;
                }

            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                success = false;
                Result = false;
            }

            ApiResponse<Boolean> response = new ApiResponse<Boolean>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = Result,
                Success = success
            };

            return response;
        }
    }
}
