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

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Queries
{
    public class GetByComplianceSourceTypeMarketByIdHandler : IRequestHandler<GetByComplianceSourceTypeMarketById, ApiResponse<IReadOnlyList<ComplianceSourceTypeMarketsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByComplianceSourceTypeMarketByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceSourceTypeMarketsResponse>>> Handle(GetByComplianceSourceTypeMarketById request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceSourceTypeMarkets> complianceSourceTypeMarkets = null;
            IReadOnlyList<ComplianceSourceTypeMarketsResponse> complianceSourceTypesResponse = null;
            String CodeResult = "";

            try
            {
                complianceSourceTypeMarkets = await _unitOfWork.complianceSourceTypeMarketsRepository.GetByComplianceSourceTypeId(request._complianceSourceTypeId);

             

                if (complianceSourceTypeMarkets != null)
                {
                    complianceSourceTypesResponse = _mapper.Map<IReadOnlyList<ComplianceSourceTypeMarketsResponse>>(complianceSourceTypeMarkets);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"Compliance Source Type Id {request._complianceSourceTypeId} Not Found";
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

            ApiResponse<IReadOnlyList<ComplianceSourceTypeMarketsResponse>> response = new ApiResponse<IReadOnlyList<ComplianceSourceTypeMarketsResponse>>
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
