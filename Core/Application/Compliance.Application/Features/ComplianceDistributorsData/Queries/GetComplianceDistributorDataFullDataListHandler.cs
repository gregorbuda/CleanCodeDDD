using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceDistributorsData.Queries
{
    /// <summary>
    /// Get Compliance Distributor Data Full Data List Handler
    /// </summary>
    public class GetComplianceDistributorDataFullDataListHandler : IRequestHandler<GetComplianceDistributorDataFullDataList, ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceDistributorDataFullDataListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>> Handle(GetComplianceDistributorDataFullDataList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceDistributorData> complianceDistributorData = null;
            IReadOnlyList<ComplianceDistributorDataResponse> complianceDistributorDataResponse = null;
            String CodeResult = "";

            try
            {
                complianceDistributorData = await _unitOfWork.complianceDistributorDataRepository.GetItemFullDataList();

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
