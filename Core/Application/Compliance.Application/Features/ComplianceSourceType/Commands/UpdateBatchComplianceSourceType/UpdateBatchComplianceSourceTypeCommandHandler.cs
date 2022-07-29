using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Compliance.Application.Features.ComplianceSourceType.Commands.UpdateBatchComplianceSourceType
{
    public class UpdateBatchComplianceSourceTypeCommandHandler : IRequestHandler<UpdateBatchComplianceSourceTypeListCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBatchComplianceSourceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(UpdateBatchComplianceSourceTypeListCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var ListcomplianceSourceType = await Validate(request);

                if (ListcomplianceSourceType.Data.Count > 0)
                {

                    _unitOfWork.complianceSourceTypesRepository.UpdateBatch(ListcomplianceSourceType.Data);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = ListcomplianceSourceType.CodeResult;
                    Message = ListcomplianceSourceType.Message;
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

        public async Task<ApiResponse<IReadOnlyList<ComplianceSourceTypes>>> Validate(UpdateBatchComplianceSourceTypeListCommand request)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            ComplianceSource ComplianceSource = null;
            ComplianceFieldType complianceFieldType = null;

            List<ComplianceSourceTypes> ListcomplianceSourceType = new List<ComplianceSourceTypes>();

            try
            {
                foreach (var ComplianceSourceTypeList in request.ComplainceSourcesType)
                {
                    var ComplianceSourceTypeToUpdate = await _unitOfWork.complianceSourceTypesRepository.GetByIdAsync(ComplianceSourceTypeList.ComplianceSourceTypeId);

                    if (ComplianceSourceTypeToUpdate != null)
                    {
                        complianceFieldType = await _unitOfWork.complianceFieldTypeRepository.GetByIdAsync(ComplianceSourceTypeList.ComplianceFieldTypeId);

                        if (complianceFieldType != null)
                        {
                            ComplianceSource = await _unitOfWork.complianceSourceRepository.GetByIdAsync(ComplianceSourceTypeList.ComplianceSourceId);

                            if (ComplianceSource != null)
                            {
                                ComplianceSourceTypes complianceSource = new ComplianceSourceTypes();
                                complianceSource.ComplianceSourceTypeId = ComplianceSourceTypeList.ComplianceSourceTypeId;
                                complianceSource.ComplianceSourceId = ComplianceSourceTypeList.ComplianceSourceId;
                                complianceSource.ComplianceFieldTypeId = ComplianceSourceTypeList.ComplianceFieldTypeId;
                                complianceSource.DistributorId = ComplianceSourceTypeList.DistributorId;
                                complianceSource.RequiresCompliance = ComplianceSourceTypeList.RequiresCompliance;
                                complianceSource.ComplianceFileSizeKb = ComplianceSourceTypeList.ComplianceFileSizeKb;
                                complianceSource.HeightPx = ComplianceSourceTypeList.HeightPx;
                                complianceSource.WidthPx = ComplianceSourceTypeList.WidthPx;
                                complianceSource.Status = ComplianceSourceTypeList.Status;
                                complianceSource.CreatedDate = ComplianceSourceTypeList.CreatedDate;
                                complianceSource.CreatedBy = ComplianceSourceTypeList.CreatedBy;
                                complianceSource.UpdatedDate = ComplianceSourceTypeList.UpdatedDate;
                                complianceSource.UpdatedBy = ComplianceSourceTypeList.UpdatedBy;

                                ListcomplianceSourceType.Add(complianceSource);
                            }
                            else
                            {
                                CodeResult = StatusCodes.Status404NotFound.ToString();
                                Message = $"Compliance Source Id {ComplianceSourceTypeList.ComplianceSourceId} Not Found";
                                Result = false;
                                success = false;
                            }
                        }
                        else
                        {
                            CodeResult = StatusCodes.Status404NotFound.ToString();
                            Message = $"Compliance File Type Id {ComplianceSourceTypeList.ComplianceFieldTypeId} Not Found";
                            Result = false;
                            success = false;
                        }
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"Compliance Source Type Id {ComplianceSourceTypeList.ComplianceSourceTypeId}  Not Found";
                        Result = false;
                        success = false;
                        break;
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

            ApiResponse<IReadOnlyList<ComplianceSourceTypes>> response = new ApiResponse<IReadOnlyList<ComplianceSourceTypes>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ListcomplianceSourceType,
                Success = success
            };

            return response;

        }
    }
}
