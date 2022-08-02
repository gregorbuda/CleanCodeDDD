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
    public class GetComplianceSourceTypeByIdListHandler : IRequestHandler<GetComplianceSourceTypeByIdList, ApiResponse<ComplianceSourceTypes>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceSourceTypeByIdListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ComplianceSourceTypes>> Handle(GetComplianceSourceTypeByIdList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            ComplianceSourceTypes ComplianceSourceTypes = null;
            ComplianceSourceTypesResponse ComplianceSourceTypesResponse = null;
            String CodeResult = "";

            try
            {
                ComplianceSourceTypes = await _unitOfWork.complianceSourceTypesRepository.GetByIdAsync(request._complianceSourceTypeId);

                //ComplianceSourceTypesResponse = _mapper.Map<ComplianceSourceTypesResponse>(ComplianceSourceTypes);

                if (ComplianceSourceTypes != null)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"Compliance Field Type Id {request._complianceSourceTypeId} Not Found";
                    ComplianceSourceTypes = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                ComplianceSourceTypes = null;
                success = false;
            }

            ApiResponse<ComplianceSourceTypes> response = new ApiResponse<ComplianceSourceTypes>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ComplianceSourceTypes,
                Success = success
            };

            return response;
        }
    }
}
