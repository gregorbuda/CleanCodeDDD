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
    public class GetByComplianceSourceTypeMarketByIdHandler : IRequestHandler<GetByComplianceSourceTypeMarketById, ApiResponse<IEnumerable<ComplianceSourceTypeMarkets>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetByComplianceSourceTypeMarketByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<ComplianceSourceTypeMarkets>>> Handle(GetByComplianceSourceTypeMarketById request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            ComplianceSourceTypes ComplianceSourceTypes = null;
            IEnumerable<ComplianceSourceTypeMarkets> complianceSourceTypeMarkets = null;
            String CodeResult = "";

            try
            {
                complianceSourceTypeMarkets = await _unitOfWork.complianceSourceTypeMarketsRepository.GetByComplianceSourceTypeId(request._complianceSourceTypeId);

                //ComplianceSourceTypesResponse = _mapper.Map<ComplianceSourceTypesResponse>(ComplianceSourceTypes);

                if (ComplianceSourceTypes.ComplianceFieldTypeId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Source Not Found";
                    complianceSourceTypeMarkets = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                complianceSourceTypeMarkets = null;
                success = false;
            }

            ApiResponse<IEnumerable<ComplianceSourceTypeMarkets>> response = new ApiResponse<IEnumerable<ComplianceSourceTypeMarkets>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceSourceTypeMarkets,
                Success = success
            };

            return response;
        }


    }
}
