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

namespace Compliance.Application.Features.ComplianceSourceType.Queries
{
    public class GetComplianceSourceTypeAllListHandler : IRequestHandler<GetComplianceSourceTypeAllList, ApiResponse<IReadOnlyList<ComplianceSourceTypesResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceSourceTypeAllListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceSourceTypesResponse>>> Handle(GetComplianceSourceTypeAllList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceSourceTypes> complianceSourceTypes = null;
            IReadOnlyList<ComplianceSourceTypesResponse> complianceSourceTypesResponse = null;
            String CodeResult = "";

            try
            {
                complianceSourceTypes = await _unitOfWork.complianceSourceTypesRepository.GetAllAsync();

                complianceSourceTypesResponse = _mapper.Map<IReadOnlyList<ComplianceSourceTypesResponse>>(complianceSourceTypes);

                if (complianceSourceTypes.Count > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Source Types Not Found";
                    complianceSourceTypesResponse = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                complianceSourceTypesResponse = null;
                success = false;
            }

            ApiResponse<IReadOnlyList<ComplianceSourceTypesResponse>> response = new ApiResponse<IReadOnlyList<ComplianceSourceTypesResponse>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceSourceTypesResponse,
                Success = success
            };

            return response;
        }
    }
}
