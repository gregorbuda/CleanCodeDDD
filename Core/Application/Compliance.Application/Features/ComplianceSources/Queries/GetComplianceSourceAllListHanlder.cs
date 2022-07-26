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
    public class GetComplianceSourceAllListHanlder : IRequestHandler<GetComplianceSourceAllList, ApiResponse<List<ComplianceSourceResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceSourceAllListHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<ComplianceSourceResponse>>> Handle(GetComplianceSourceAllList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            ComplianceSourceResponse complianceSourceResponse = null;
            IReadOnlyList<ComplianceSource> ComplianceSource = null;
            List<ComplianceSourceResponse> ComplianceSourceResponseList = new List<ComplianceSourceResponse>();
            List<ComplianceSourceTypes> complianceSourceTypes = null;
            List<ComplianceSourceTypesResponse> complianceSourceTypesResponseList = new List<ComplianceSourceTypesResponse>();
            String CodeResult = "";

            try
            {
                ComplianceSource = await _unitOfWork.complianceSourceRepository.GetAllAsync();

                if (ComplianceSource.Count > 0)
                {
                    foreach (var ComplianceSourceList in ComplianceSource)
                    {
                        complianceSourceResponse = new ComplianceSourceResponse();

                        complianceSourceTypes = await _unitOfWork.complianceSourceTypesRepository.GetComplianceSourceTypeByCompianceSourceId(ComplianceSourceList.ComplianceSourceId);

                        foreach (var complianceSourceTypesList in complianceSourceTypes)
                        {
                          
                            ComplianceSourceTypesResponse complianceSourceTypesResponse = new ComplianceSourceTypesResponse();
                            complianceSourceTypesResponse.Status = (EnumComplianceSourceStatus)complianceSourceTypesList.Status;
                            complianceSourceTypesResponse.ComplianceFieldTypeId = complianceSourceTypesList.ComplianceFieldTypeId;
                            complianceSourceTypesResponse.ComplianceFileSizeKb = complianceSourceTypesList.ComplianceFileSizeKb;
                            complianceSourceTypesResponse.ComplianceSourceId = complianceSourceTypesList.ComplianceSourceId;
                            complianceSourceTypesResponse.ComplianceSourceTypeId = complianceSourceTypesList.ComplianceSourceTypeId;
                            complianceSourceTypesResponse.DistributorId = complianceSourceTypesList.DistributorId;
                            complianceSourceTypesResponse.RequiresCompliance = complianceSourceTypesList.RequiresCompliance;
                            complianceSourceTypesResponse.HeightPx = complianceSourceTypesList.HeightPx;
                            complianceSourceTypesResponse.WidthPx = complianceSourceTypesList.WidthPx;

                            complianceSourceTypesResponseList.Add(complianceSourceTypesResponse);
                        }

                        complianceSourceResponse.ComplianceSourceId = ComplianceSourceList.ComplianceSourceId;
                        complianceSourceResponse.ComplianceSourceName = ComplianceSourceList.ComplianceSourceName;
                        complianceSourceResponse.Status = (EnumComplianceSourceStatus)ComplianceSourceList.Status;
                        complianceSourceResponse.ComplianceSourceType = complianceSourceTypesResponseList;

                        complianceSourceTypesResponseList = null;

                        ComplianceSourceResponseList.Add(complianceSourceResponse);

                    }

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

            ApiResponse<List<ComplianceSourceResponse>> response = new ApiResponse<List<ComplianceSourceResponse>>
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
