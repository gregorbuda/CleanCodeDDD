using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Queries
{
    public class GetComplianceSourceTypeMarketByIdHandler : IRequestHandler<GetComplianceSourceTypeMarketById, ApiResponse<ComplianceSourceTypeMarketsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceSourceTypeMarketByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceSourceTypeMarketsResponse>> Handle(GetComplianceSourceTypeMarketById request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            ComplianceSourceTypeMarkets complianceSourceTypeMarkets = null;
            ComplianceSourceTypeMarketsResponse complianceSourceTypesResponse = null;
            String CodeResult = "";

            try
            {
                complianceSourceTypeMarkets = await _unitOfWork.complianceSourceTypeMarketsRepository.GetByIdAsync(request._complianceSourceTypeMarketId);

                if (complianceSourceTypeMarkets != null)
                {
                    complianceSourceTypesResponse = _mapper.Map<ComplianceSourceTypeMarketsResponse>(complianceSourceTypeMarkets);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"Compliance Source Type Id {request._complianceSourceTypeMarketId} Not Found";
                    complianceSourceTypesResponse = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                complianceSourceTypesResponse = null;
                success = false;
            }

            ApiResponse<ComplianceSourceTypeMarketsResponse> response = new ApiResponse<ComplianceSourceTypeMarketsResponse>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceSourceTypesResponse,
                Success = success
            };

            return response;
        }
    }
}
