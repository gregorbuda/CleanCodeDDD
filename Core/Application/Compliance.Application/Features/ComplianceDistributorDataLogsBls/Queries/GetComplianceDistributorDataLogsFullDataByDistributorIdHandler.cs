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

namespace Compliance.Application.Features.ComplianceDistributorDataLogsBls.Queries
{
    /// <summary>
    /// Get Compliance Distributor Data Logs Full Data By Distributor Id Handler
    /// </summary>
    public class GetComplianceDistributorDataLogsFullDataByDistributorIdHandler : IRequestHandler<GetComplianceDistributorDataLogsFullDataByDistributorId, ApiResponse<IReadOnlyList<ComplianceDistributorDataLogsResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceDistributorDataLogsFullDataByDistributorIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceDistributorDataLogsResponse>>> Handle(GetComplianceDistributorDataLogsFullDataByDistributorId request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceDistributorDataLogs> complianceDistributorDataLogs = null;
            IReadOnlyList<ComplianceDistributorDataLogsResponse> complianceDistributorDataLogsResponse = null;
            String CodeResult = "";

            try
            {
                complianceDistributorDataLogs = await _unitOfWork.complianceDistributorDataLogsRepository.ItemFullDataListByDistributorId(request._complianceDistributorDataId);

                if (complianceDistributorDataLogs.Count > 0)
                {
                    complianceDistributorDataLogsResponse = _mapper.Map<IReadOnlyList<ComplianceDistributorDataLogsResponse>>(complianceDistributorDataLogs);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Distributor Data Logs Not Found";
                    complianceDistributorDataLogsResponse = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                complianceDistributorDataLogsResponse = null;
                success = false;
            }

            ApiResponse<IReadOnlyList<ComplianceDistributorDataLogsResponse>> response = new ApiResponse<IReadOnlyList<ComplianceDistributorDataLogsResponse>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceDistributorDataLogsResponse,
                Success = success
            };

            return response;
        }
    }
}
