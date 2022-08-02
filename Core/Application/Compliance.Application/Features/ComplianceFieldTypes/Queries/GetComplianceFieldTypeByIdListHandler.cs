using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceFieldTypes.Queries
{
    public class GetComplianceFieldTypeByIdListHandler : IRequestHandler<GetComplianceFieldTypeByIdList, ApiResponse<ComplianceFieldType>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceFieldTypeByIdListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceFieldType>> Handle(GetComplianceFieldTypeByIdList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            ComplianceFieldType complianceFieldType = null;
            ComplianceFieldTypeResponse complianceFieldTypeResponse = null;
            String CodeResult = "";

            try
            {
                complianceFieldType = await _unitOfWork.complianceFieldTypeRepository.GetByIdAsync(request._complianceFieldTypeId);

                //complianceFieldTypeResponse = _mapper.Map<ComplianceFieldTypeResponse>(complianceFieldType);

                if (complianceFieldType.ComplianceFieldTypeId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"Compliance Field Type Id {request._complianceFieldTypeId} Not Found";
                    complianceFieldType = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                complianceFieldType = null;
                success = false;
            }

            ApiResponse<ComplianceFieldType> response = new ApiResponse<ComplianceFieldType>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceFieldType,
                Success = success
            };

            return response;
        }
    }
}
