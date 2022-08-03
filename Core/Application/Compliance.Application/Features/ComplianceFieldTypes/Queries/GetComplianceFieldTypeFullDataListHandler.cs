using AutoMapper;
using Compliance.Application.Contracts.Persistence;
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
    /// <summary>
    /// Get Compliance Field Type Full Data List Handler
    /// </summary>
    public class GetComplianceFieldTypeFullDataListHandler : IRequestHandler<GetComplianceFieldTypeFullDataList, ApiResponse<IReadOnlyList<ComplianceFieldTypeFullDataResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceFieldTypeFullDataListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceFieldTypeFullDataResponse>>> Handle(GetComplianceFieldTypeFullDataList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceFieldType> ComplianceSourceFieldType = null;
            IReadOnlyList<ComplianceFieldTypeFullDataResponse> ComplianceSourceResponseFieldType = null;
            String CodeResult = "";

            try
            {
                ComplianceSourceFieldType = await _unitOfWork.complianceFieldTypeRepository.GetItemFullDataList();
           
                if (ComplianceSourceFieldType != null)
                {
                    ComplianceSourceResponseFieldType = _mapper.Map<IReadOnlyList<ComplianceFieldTypeFullDataResponse>>(ComplianceSourceFieldType);

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

            ApiResponse<IReadOnlyList<ComplianceFieldTypeFullDataResponse>> response = new ApiResponse<IReadOnlyList<ComplianceFieldTypeFullDataResponse>>
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
