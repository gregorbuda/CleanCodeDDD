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

namespace Compliance.Application.Features.ComplianceDistributorsData.Queries
{
    public class GetComplianceDistributorDataFullDataByDistributorIdHandler : IRequestHandler<GetComplianceDistributorDataFullDataByDistributorId, ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceDistributorDataFullDataByDistributorIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>> Handle(GetComplianceDistributorDataFullDataByDistributorId request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceDistributorData> complianceDistributorData = null;
            IReadOnlyList<ComplianceDistributorDataResponse> complianceDistributorDataResponse = null;
            String CodeResult = "";

            try
            {
                complianceDistributorData = await _unitOfWork.complianceDistributorDataRepository.ItemFullDataListByDistributor(request._complianceDistributorDataId);

                if (complianceDistributorData != null)
                {
                    complianceDistributorDataResponse = _mapper.Map<IReadOnlyList<ComplianceDistributorDataResponse>>(complianceDistributorData);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Distributor Data Not Found";
                    complianceDistributorDataResponse = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                complianceDistributorDataResponse = null;
                success = false;
            }

            ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>> response = new ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceDistributorDataResponse,
                Success = success
            };

            return response;
        }
    }
}
