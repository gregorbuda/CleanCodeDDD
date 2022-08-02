using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceFieldTypes.Queries
{
    public class GetComplianceFieldTypeFullDataByIdHandler : IRequestHandler<GetComplianceFieldTypeFullDataById, ApiResponse<ComplianceFieldTypeFullDataResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceFieldTypeFullDataByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<ApiResponse<ComplianceFieldTypeFullDataResponse>> Handle(GetComplianceFieldTypeFullDataById request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            ComplianceFieldType complianceFieldType = null;
            ComplianceFieldTypeFullDataResponse ComplianceSourceResponseFieldType = null;
            String CodeResult = "";

            try
            {
                complianceFieldType = await _unitOfWork.complianceFieldTypeRepository.GetFullDataById(request._complianceFieldTypeId);

                if (complianceFieldType != null)
                {
                    ComplianceSourceResponseFieldType = _mapper.Map<ComplianceFieldTypeFullDataResponse>(complianceFieldType);

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

            ApiResponse<ComplianceFieldTypeFullDataResponse> response = new ApiResponse<ComplianceFieldTypeFullDataResponse>
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
