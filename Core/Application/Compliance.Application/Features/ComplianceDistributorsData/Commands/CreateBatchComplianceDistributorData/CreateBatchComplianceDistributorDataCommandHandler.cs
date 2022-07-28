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

namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.CreateBatchComplianceDistributorData
{
    public class CreateBatchComplianceDistributorDataCommandHandler : IRequestHandler<CreateBatchComplianceDistributorDataListCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBatchComplianceDistributorDataCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(CreateBatchComplianceDistributorDataListCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var ListcomplianceDistributorData = await Validate(request);

                if (ListcomplianceDistributorData.Data.Count > 0)
                {

                    var result = _unitOfWork.complianceDistributorDataRepository.SaveBatch(ListcomplianceDistributorData.Data);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = ListcomplianceDistributorData.CodeResult;
                    Message = ListcomplianceDistributorData.Message;
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

        public async Task<ApiResponse<IReadOnlyList<ComplianceDistributorData>>> Validate(CreateBatchComplianceDistributorDataListCommand request)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            ComplianceSourceTypes ComplianceSourceTypes = null;
            ComplianceDistributorData complianceDistributorData = new ComplianceDistributorData();
            List<ComplianceDistributorData> ListcomplianceDistributorData = new List<ComplianceDistributorData>();
            try
            {
                foreach (var complianceDistributorDataList in request.ComplianceDistributorData)
                {

                    ComplianceSourceTypes = await _unitOfWork.complianceSourceTypesRepository.GetByIdAsync(complianceDistributorDataList.ComplianceSourceTypeId);

                    if (ComplianceSourceTypes != null)
                    {
                        complianceDistributorData.ComplianceSourceTypeId = complianceDistributorDataList.ComplianceSourceTypeId;
                        complianceDistributorData.DistributorId = complianceDistributorDataList.DistributorId;
                        complianceDistributorData.FieldData = complianceDistributorDataList.FieldData;
                        complianceDistributorData.Status = complianceDistributorDataList.Status;
                        complianceDistributorData.CreatedDate = complianceDistributorDataList.CreatedDate;
                        complianceDistributorData.CreatedBy = complianceDistributorDataList.CreatedBy;
                        complianceDistributorData.UpdatedDate = complianceDistributorDataList.UpdatedDate;
                        complianceDistributorData.UpdatedBy = complianceDistributorDataList.UpdatedBy;

                        ListcomplianceDistributorData.Add(complianceDistributorData);
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"Compliance Source Types Id {complianceDistributorDataList.ComplianceSourceTypeId} Not Found";
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

            ApiResponse<IReadOnlyList<ComplianceDistributorData>> response = new ApiResponse<IReadOnlyList<ComplianceDistributorData>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ListcomplianceDistributorData,
                Success = success
            };

            return response;

        }
    }
}
