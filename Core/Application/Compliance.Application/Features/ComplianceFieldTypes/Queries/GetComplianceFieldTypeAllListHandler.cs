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

namespace Compliance.Application.Features.ComplianceFieldTypes.Queries
{
    public class GetComplianceFieldTypeAllListHandler : IRequestHandler<GetComplianceFieldTypeAllList, ApiResponse<IReadOnlyList<ComplianceFieldTypeResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceFieldTypeAllListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceFieldTypeResponse>>> Handle(GetComplianceFieldTypeAllList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceFieldType> ComplianceSourceFieldType = null;
            IReadOnlyList<ComplianceFieldTypeResponse> ComplianceSourceResponseFieldType = null;
            String CodeResult = "";

            try
            {
                ComplianceSourceFieldType = await _unitOfWork.complianceFieldTypeRepository.GetAllAsync();

                ComplianceSourceResponseFieldType = _mapper.Map<IReadOnlyList<ComplianceFieldTypeResponse>>(ComplianceSourceFieldType);

                if (ComplianceSourceFieldType.Count > 0)
                {
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

            ApiResponse<IReadOnlyList<ComplianceFieldTypeResponse>> response = new ApiResponse<IReadOnlyList<ComplianceFieldTypeResponse>>
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
