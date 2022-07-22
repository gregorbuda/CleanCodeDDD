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

namespace Compliance.Application.Features.ComplianceSourceType.Commands.CreateComplianceSourceType
{
    public class CreateComplianceSourceTypeCommandHandler : IRequestHandler<CreateComplianceSourceTypeCommand, ApiResponse<ComplianceSourceTypeCreateResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateComplianceSourceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceSourceTypeCreateResponse>> Handle(CreateComplianceSourceTypeCommand request, CancellationToken cancellationToken)
        {
            var complianceSourceEntity = _mapper.Map<ComplianceSourceTypes>(request);

            ComplianceSourceTypes complianceSourceTypes = null;
            ComplianceSourceTypeCreateResponse objReponse = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                complianceSourceTypes = await _unitOfWork.complianceSourceTypesRepository.AddAsync(complianceSourceEntity);

                objReponse = _mapper.Map<ComplianceSourceTypeCreateResponse>(complianceSourceTypes);

                if (complianceSourceTypes.ComplianceSourceTypeId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "No se pudo registrar el Compliance Source Type";
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

            ApiResponse<ComplianceSourceTypeCreateResponse> response = new ApiResponse<ComplianceSourceTypeCreateResponse>
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
