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

namespace Compliance.Application.Features.ComplianceSourceType.Commands.UpdateComplianceSourceType
{
    public class UpdateComplianceSourceTypeCommandHandler : IRequestHandler<UpdateComplianceSourceTypeCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateComplianceSourceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(UpdateComplianceSourceTypeCommand request, CancellationToken cancellationToken)
        {
            ComplianceSource ComplianceSource = null;
            ComplianceFieldType complianceFieldType = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                ComplianceSource = await _unitOfWork.complianceSourceRepository.GetByIdAsync(request.ComplianceSourceId);

                if (ComplianceSource != null)
                {
                    complianceFieldType = await _unitOfWork.complianceFieldTypeRepository.GetByIdAsync(request.ComplianceFieldTypeId);

                    if (complianceFieldType != null)
                    {
                        var ComplianceSourceTypeToUpdate = await _unitOfWork.complianceSourceTypesRepository.GetByIdAsync(request.ComplianceSourceTypeId);

                        if (ComplianceSourceTypeToUpdate != null)
                        {
                            _mapper.Map(request, ComplianceSourceTypeToUpdate, typeof(UpdateComplianceSourceTypeCommand), typeof(ComplianceSourceTypes));

                            _unitOfWork.complianceSourceTypesRepository.UpdateEntity(ComplianceSourceTypeToUpdate);

                            await _unitOfWork.Complete();

                            CodeResult = StatusCodes.Status200OK.ToString();
                            Message = "Success, and there is a response body.";
                            success = true;
                            Result = true;
                        }
                        else
                        {
                            CodeResult = StatusCodes.Status404NotFound.ToString();
                            Message = $"Compliance Source Type Id {request.ComplianceSourceTypeId} Not Found";
                            Result = false;
                            success = false;
                        }
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"Compliance Source Type Id {request.ComplianceFieldTypeId} Not Found";
                        Result = false;
                        success = false;
                    }
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"Compliance Source Id {request.ComplianceSourceId} Not Found";
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
