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

namespace Compliance.Application.Features.ComplianceSources.Queries
{
    /// <summary>
    /// Get Compliance Source All List
    /// </summary>
    public class GetComplianceSourceByIdListHandler : IRequestHandler<GetComplianceSourceByIdList, ApiResponse<ComplianceSourceResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceSourceByIdListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceSourceResponse>> Handle(GetComplianceSourceByIdList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            ComplianceSource ComplianceSource = null;
            ComplianceSourceResponse ComplianceSourceResponse = null;
            String CodeResult = "";

            try
            {
                ComplianceSource = await _unitOfWork.complianceSourceRepository.GetByIdAsync(request._complianceSourceId);

                if (ComplianceSource != null)
                {
                    ComplianceSourceResponse = _mapper.Map<ComplianceSourceResponse>(ComplianceSource);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"Compliance Source Id {request._complianceSourceId} Not Found";
                    ComplianceSourceResponse = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                ComplianceSourceResponse = null;
                success = false;
            }

            ApiResponse<ComplianceSourceResponse> response = new ApiResponse<ComplianceSourceResponse>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ComplianceSourceResponse,
                Success = success
            };

            return response;
        }
    }
}
