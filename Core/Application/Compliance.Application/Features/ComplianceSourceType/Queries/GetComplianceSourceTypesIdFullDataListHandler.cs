using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    /// <summary>
    /// Get Compliance Source Type Full Data Data List Handler
    /// </summary>
    public class ComplianceSourceTypesIdFullDataListHandler : IRequestHandler<GetComplianceSourceTypesIdFullDataList, ApiResponse<IReadOnlyList<ComplianceSourceTypesFullDataResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComplianceSourceTypesIdFullDataListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceSourceTypesFullDataResponse>>> Handle(GetComplianceSourceTypesIdFullDataList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceSourceTypes> ComplianceSourceFieldType = null;
            IReadOnlyList<ComplianceSourceTypesFullDataResponse> ComplianceSourceResponseFieldType = null;
            String CodeResult = "";

            try
            {
                ComplianceSourceFieldType = await _unitOfWork.complianceSourceTypesRepository.GetItemFullDataList();

                if (ComplianceSourceFieldType != null)
                {
                    ComplianceSourceResponseFieldType = _mapper.Map<IReadOnlyList<ComplianceSourceTypesFullDataResponse>>(ComplianceSourceFieldType);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Field Type Not Found";
                    ComplianceSourceResponseFieldType = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                ComplianceSourceResponseFieldType = null;
                success = false;
            }

            ApiResponse<IReadOnlyList<ComplianceSourceTypesFullDataResponse>> response = new ApiResponse<IReadOnlyList<ComplianceSourceTypesFullDataResponse>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ComplianceSourceResponseFieldType,
                Success = success
            };

            return response;
        }
    }
}
