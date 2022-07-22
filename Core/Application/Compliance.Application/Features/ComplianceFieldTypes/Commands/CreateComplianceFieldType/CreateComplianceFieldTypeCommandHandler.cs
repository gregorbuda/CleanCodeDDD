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

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.CreateComplianceFieldType
{
    public class CreateComplianceFieldTypeCommandHandler : IRequestHandler<CreateComplianceFieldTypeCommand, ApiResponse<ComplianceFieldTypeCreateResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateComplianceFieldTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceFieldTypeCreateResponse>> Handle(CreateComplianceFieldTypeCommand request, CancellationToken cancellationToken)
        {
            var complianceSourceEntity = _mapper.Map<ComplianceFieldType>(request);

            ComplianceFieldType complianceFieldType = null;
            ComplianceFieldTypeCreateResponse objReponse = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                complianceFieldType = await _unitOfWork.complianceFieldTypeRepository.AddAsync(complianceSourceEntity);

                objReponse = _mapper.Map<ComplianceFieldTypeCreateResponse>(complianceFieldType);

                if (complianceFieldType.ComplianceFieldTypeId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "No se pudo registrar el ComplianceSource";
                    objReponse = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                success = false;
                objReponse = null;
            }

            ApiResponse<ComplianceFieldTypeCreateResponse> response = new ApiResponse<ComplianceFieldTypeCreateResponse>
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
