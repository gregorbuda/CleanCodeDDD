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

namespace Compliance.Application.Features.ComplianceSources.Queries
{
    public class GetComplianceSourceAllListHanlder : IRequestHandler<GetComplianceSourceAllList, ApiResponse<IReadOnlyList<ComplianceSourceResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceSourceAllListHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceSourceResponse>>> Handle(GetComplianceSourceAllList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceSource> ComplianceSource = null;
            IReadOnlyList<ComplianceSourceResponse> ComplianceSourceResponseList = new List<ComplianceSourceResponse>();
       
            String CodeResult = "";

            try
            {
                ComplianceSource = await _unitOfWork.complianceSourceRepository.GetAllAsync();

                if (ComplianceSource.Count > 0)
                {
                    ComplianceSourceResponseList = _mapper.Map<IReadOnlyList<ComplianceSourceResponse>>(ComplianceSource);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Source Not Found";
                    ComplianceSourceResponseList = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                ComplianceSourceResponseList = null;
                success = false;
            }

            ApiResponse<IReadOnlyList<ComplianceSourceResponse>> response = new ApiResponse<IReadOnlyList<ComplianceSourceResponse>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ComplianceSourceResponseList,
                Success = success
            };

            return response;
        }
    }
}
