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

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateComplianceFieldType
{
    public class UpdateComplianceFieldTypeCommandHandler : IRequestHandler<UpdateComplianceFieldTypeCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateComplianceFieldTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateComplianceFieldTypeCommand request, CancellationToken cancellationToken)
        {
            FileResourceType fileResourceType = null;
            InputBehaviour inputBehaviour = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                fileResourceType = await _unitOfWork.fileResourceTypeRepository.GetByIdAsync(request.FileResourceTypeId);

                if (fileResourceType != null)
                {
                    inputBehaviour = await _unitOfWork.inputBehaviourRepository.GetByIdAsync(request.InputBehaviourId);

                    if (inputBehaviour != null)
                    {
                        var ComplianceFieldTypeToUpdate = await _unitOfWork.complianceFieldTypeRepository.GetByIdAsync(request.ComplianceFieldTypeId);

                        if (ComplianceFieldTypeToUpdate != null)
                        {
                            _mapper.Map(request, ComplianceFieldTypeToUpdate, typeof(UpdateComplianceFieldTypeCommand), typeof(ComplianceFieldType));

                            _unitOfWork.complianceFieldTypeRepository.UpdateEntity(ComplianceFieldTypeToUpdate);

                            await _unitOfWork.Complete();

                            CodeResult = StatusCodes.Status200OK.ToString();
                            Message = "Success, and there is a response body.";
                            success = true;
                            Result = true;
                        }
                        else
                        {
                            CodeResult = StatusCodes.Status404NotFound.ToString();
                            Message = $"Compliance Field Type Id {request.ComplianceFieldTypeId} Not Found";
                            Result = false;
                            success = false;
                        }
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"input Behaviour Id {request.InputBehaviourId} Not Found";
                        Result = false;
                        success = false;
                    }
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"File Resource Type Id {request.FileResourceTypeId} Not Found";
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
