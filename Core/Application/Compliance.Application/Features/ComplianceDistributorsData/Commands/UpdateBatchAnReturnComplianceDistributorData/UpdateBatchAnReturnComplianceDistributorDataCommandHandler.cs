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

namespace Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchAnReturnComplianceDistributorData
{
    public class UpdateBatchAnReturnComplianceDistributorDataCommandHandler : IRequestHandler<UpdateBatchAnReturnComplianceDistributorDataListCommand, ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBatchAnReturnComplianceDistributorDataCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>> Handle(UpdateBatchAnReturnComplianceDistributorDataListCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            IReadOnlyList<ComplianceDistributorDataResponse> complianceDistributorDataResponse = null;
            try
            {
                var ListcomplianceDistributorData = await Validate(request);

                if (ListcomplianceDistributorData.Data.Count > 0)
                {

                    _unitOfWork.complianceDistributorDataRepository.UpdateBatch(ListcomplianceDistributorData.Data);

                   complianceDistributorDataResponse = _mapper.Map<IReadOnlyList<ComplianceDistributorDataResponse>>(ListcomplianceDistributorData.Data);

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

            ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>> response = new ApiResponse<IReadOnlyList<ComplianceDistributorDataResponse>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceDistributorDataResponse,
                Success = success
            };

            return response;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceDistributorData>>> Validate(UpdateBatchAnReturnComplianceDistributorDataListCommand request)
        {
            Boolean success = false;
            String Message = Message = "Success, and there is a response body.";
            String CodeResult = StatusCodes.Status200OK.ToString();
            Boolean Result = false;
            ComplianceSourceTypes ComplianceSourceTypes = null;
         
            List<ComplianceDistributorData> ListcomplianceDistributorData = new List<ComplianceDistributorData>();
            try
            {
                foreach (var complianceDistributorDataList in request.ComplianceDistributorData)
                {
                    var complianceDistributorDataById = await _unitOfWork.complianceDistributorDataRepository.GetByIdAsync(complianceDistributorDataList.ComplianceDistributorDataId);

                    if (complianceDistributorDataById != null)
                    {
                        ComplianceSourceTypes = await _unitOfWork.complianceSourceTypesRepository.GetByIdAsync(complianceDistributorDataList.ComplianceSourceTypeId);

                        if (ComplianceSourceTypes != null)
                        {
                            ComplianceDistributorData complianceDistributorData = new ComplianceDistributorData();
                            complianceDistributorData.ComplianceDistributorDataId = complianceDistributorDataList.ComplianceDistributorDataId;
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
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"compliance Distributor Data Id {complianceDistributorDataList.ComplianceDistributorDataId} Not Found";
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
