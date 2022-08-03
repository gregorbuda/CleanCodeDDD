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

namespace Compliance.Application.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls
{
    /// <summary>
    /// Create Batch Compliance Distributor Data Logs Bls List Command Handler
    /// </summary>
    public class CreateBatchComplianceDistributorDataLogsBlsCommandHandler : IRequestHandler<CreateBatchComplianceDistributorDataLogsBlsListCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBatchComplianceDistributorDataLogsBlsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ApiResponse<Boolean>> Handle(CreateBatchComplianceDistributorDataLogsBlsListCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var ListcomplianceDistributorDataLogs = await Validate(request);

                if (ListcomplianceDistributorDataLogs.Data.Count > 0)
                {

                    _unitOfWork.complianceDistributorDataLogsRepository.SaveBatch(ListcomplianceDistributorDataLogs.Data);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = ListcomplianceDistributorDataLogs.CodeResult;
                    Message = ListcomplianceDistributorDataLogs.Message;
                    success = false;
                    Result = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                success = false;
                Result = false;
            }

            ApiResponse<Boolean> response = new ApiResponse<Boolean>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = Result,
                Success = success
            };

            return response;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceDistributorDataLogs>>> Validate(CreateBatchComplianceDistributorDataLogsBlsListCommand request)
        {
            Boolean success = false;
            String Message = Message = "Success, and there is a response body.";
            String CodeResult = StatusCodes.Status200OK.ToString();
            Boolean Result = false;
            ComplianceDistributorData complianceDistributorData = null;

            List<ComplianceDistributorDataLogs> ListcomplianceDistributorDataLogs = new List<ComplianceDistributorDataLogs>();
            try
            {
                foreach (var complianceDistributorDataLogsList in request.complianceDistributorDataLogs)
                {
                    complianceDistributorData = await _unitOfWork.complianceDistributorDataRepository.GetByIdAsync(complianceDistributorDataLogsList.ComplianceDistributorDataId);

                    if (complianceDistributorData != null)
                    {
                        ComplianceDistributorDataLogs complianceDistributorDataLogs = new ComplianceDistributorDataLogs();
                        complianceDistributorDataLogs.ComplianceDistributorLogMessage = complianceDistributorDataLogsList.ComplianceDistributorLogMessage;
                        complianceDistributorDataLogs.ComplianceDistributorLogData = complianceDistributorDataLogsList.ComplianceDistributorLogData;
                        complianceDistributorDataLogs.ComplianceDistributorDataId = complianceDistributorDataLogsList.ComplianceDistributorDataId;
                        complianceDistributorDataLogs.Status = complianceDistributorDataLogsList.Status;
                        complianceDistributorDataLogs.CreatedDate = complianceDistributorDataLogsList.CreatedDate;
                        complianceDistributorDataLogs.CreatedBy = complianceDistributorDataLogsList.CreatedBy;
                        complianceDistributorDataLogs.UpdatedDate = complianceDistributorDataLogsList.UpdatedDate;
                        complianceDistributorDataLogs.UpdatedBy = complianceDistributorDataLogsList.UpdatedBy;

                        ListcomplianceDistributorDataLogs.Add(complianceDistributorDataLogs);
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"Compliance Distributor Data Id {complianceDistributorDataLogsList.ComplianceDistributorDataId} Not Found";
                        Result = false;
                        success = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                success = false;
                Result = false;
            }

            ApiResponse<IReadOnlyList<ComplianceDistributorDataLogs>> response = new ApiResponse<IReadOnlyList<ComplianceDistributorDataLogs>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ListcomplianceDistributorDataLogs,
                Success = success
            };

            return response;

        }
    }
}
