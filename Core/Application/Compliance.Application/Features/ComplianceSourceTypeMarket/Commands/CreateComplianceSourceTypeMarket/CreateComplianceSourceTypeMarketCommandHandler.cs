using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateComplianceSourceTypeMarket
{
    /// <summary>
    /// Create  Compliance Source Type Market Command Handler
    /// </summary>
    public class CreateComplianceSourceTypeMarketCommandHandler : IRequestHandler<CreateComplianceSourceTypeMarketCommand, ApiResponse<ComplianceSourceTypeMarketsCreateResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateComplianceSourceTypeMarketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceSourceTypeMarketsCreateResponse>> Handle(CreateComplianceSourceTypeMarketCommand request, CancellationToken cancellationToken)
        {
            var complianceSourceTypeMarketsEntity = _mapper.Map<ComplianceSourceTypeMarkets>(request);

            ComplianceSourceTypes complianceSourceTypes = null;
            ComplianceSourceTypeMarkets complianceSourceTypeMarkets = null;
            ComplianceSourceTypeMarketsCreateResponse objReponse = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                complianceSourceTypes = await _unitOfWork.complianceSourceTypesRepository.GetByIdAsync(request.ComplianceSourceTypeId);

                if (complianceSourceTypes != null)
                {
                    complianceSourceTypeMarkets = await _unitOfWork.complianceSourceTypeMarketsRepository.AddAsync(complianceSourceTypeMarketsEntity);

                    objReponse = _mapper.Map<ComplianceSourceTypeMarketsCreateResponse>(complianceSourceTypeMarkets);

                    if (complianceSourceTypeMarkets.ComplianceSourceTypeMarketId > 0)
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
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"Compliance Source Type Id {request.ComplianceSourceTypeId} Not Found";
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

            ApiResponse<ComplianceSourceTypeMarketsCreateResponse> response = new ApiResponse<ComplianceSourceTypeMarketsCreateResponse>
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
