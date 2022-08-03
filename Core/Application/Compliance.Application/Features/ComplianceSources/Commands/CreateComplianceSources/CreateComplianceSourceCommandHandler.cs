using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources
{
    /// <summary>
    /// Create Compliance Source Command Handler
    /// </summary>
    public class CreateComplianceSourceCommandHandler : IRequestHandler<CreateComplianceSourceCommand, ApiResponse<ComplianceSourceCreateResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateComplianceSourceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceSourceCreateResponse>> Handle(CreateComplianceSourceCommand request, CancellationToken cancellationToken)
        {
            var complianceSourceEntity = _mapper.Map<ComplianceSource>(request);

            ComplianceSource complianceSource = null;
            ComplianceSourceCreateResponse objReponse = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                complianceSource = await _unitOfWork.complianceSourceRepository.AddAsync(complianceSourceEntity);

                 objReponse = _mapper.Map<ComplianceSourceCreateResponse>(complianceSource);

                if (complianceSource.ComplianceSourceId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "No se pudo registrar el ComplianceSource";
                    complianceSource = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                success = false;
                complianceSource = null;
            }

            ApiResponse<ComplianceSourceCreateResponse> response = new ApiResponse<ComplianceSourceCreateResponse>
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
