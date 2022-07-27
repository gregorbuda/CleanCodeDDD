using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    public class GetComplianceSourceTypeFullDataByIdHandler : IRequestHandler<GetComplianceSourceTypeFullDataById, ApiResponse<ComplianceSourceTypesFullDataResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceSourceTypeFullDataByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceSourceTypesFullDataResponse>> Handle(GetComplianceSourceTypeFullDataById request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            ComplianceSourceTypes ComplianceSourceFieldType = null;
            ComplianceSourceTypesFullDataResponse ComplianceSourceResponseFieldType = null;
            String CodeResult = "";

            try
            {
                ComplianceSourceFieldType = await _unitOfWork.complianceSourceTypesRepository.GetFullDataById(request._complianceSourceTypeId);

                if (ComplianceSourceFieldType != null)
                {
                    ComplianceSourceResponseFieldType = _mapper.Map<ComplianceSourceTypesFullDataResponse>(ComplianceSourceFieldType);

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

            ApiResponse<ComplianceSourceTypesFullDataResponse> response = new ApiResponse<ComplianceSourceTypesFullDataResponse>
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
