using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.UpdateBatchComplianceFieldType
{
    public class UpdateBatchComplianceFieldTypeCommandHandler : IRequestHandler<UpdateBatchComplianceFieldTypeListCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBatchComplianceFieldTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(UpdateBatchComplianceFieldTypeListCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            FileResourceType fileResourceType = null;
            InputBehaviour inputBehaviour = null;
            ComplianceFieldType complianceFieldType = new ComplianceFieldType();
            ApiResponse<IReadOnlyList<ComplianceFieldType>> complianceFieldTypeList = null;
            try
            {
                var ListcomplianceFieldType = await Validate(request);

                if (ListcomplianceFieldType.Data.Count > 0)
                {
                    var result = _unitOfWork.complianceFieldTypeRepository.UpdateBatch(ListcomplianceFieldType.Data);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = ListcomplianceFieldType.CodeResult;
                    Message = ListcomplianceFieldType.Message;
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

        public async Task<ApiResponse<IReadOnlyList<ComplianceFieldType>>> Validate(UpdateBatchComplianceFieldTypeListCommand request)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            FileResourceType fileResourceType = null;
            InputBehaviour inputBehaviour = null;
            ComplianceFieldType complianceFieldType = new ComplianceFieldType();
            List<ComplianceFieldType> complianceFieldTypeList = new List<ComplianceFieldType>();

            try
            {
                foreach (var ComplianceFieldList in request.ComplainceFieldTypeList)
                {
                    var ComplianceSourceToUpdate = await _unitOfWork.complianceFieldTypeRepository.GetByIdAsync(ComplianceFieldList.ComplianceFieldTypeId);

                    if (ComplianceSourceToUpdate != null)
                    {
                        fileResourceType = await _unitOfWork.fileResourceTypeRepository.GetByIdAsync(ComplianceFieldList.FileResourceTypeId);

                        if (fileResourceType != null)
                        {
                            inputBehaviour = await _unitOfWork.inputBehaviourRepository.GetByIdAsync(ComplianceFieldList.InputBehaviourId);

                            if (inputBehaviour != null)
                            {
                                complianceFieldType.ComplianceFieldTypeId = ComplianceFieldList.ComplianceFieldTypeId;
                                complianceFieldType.ComplianceFieldTypeName = ComplianceFieldList.ComplianceFieldTypeName;
                                complianceFieldType.TranslationKey = ComplianceFieldList.TranslationKey;
                                complianceFieldType.FieldPath = ComplianceFieldList.FieldPath;
                                complianceFieldType.ComplianceFileSizeKb = ComplianceFieldList.ComplianceFileSizeKb;
                                complianceFieldType.HeightPx = ComplianceFieldList.HeightPx;
                                complianceFieldType.WidthPx = ComplianceFieldList.WidthPx;
                                complianceFieldType.Status = ComplianceFieldList.Status;
                                complianceFieldType.CreatedDate = ComplianceFieldList.CreatedDate;
                                complianceFieldType.CreatedBy = ComplianceFieldList.CreatedBy;
                                complianceFieldType.UpdatedDate = ComplianceFieldList.UpdatedDate;
                                complianceFieldType.UpdatedBy = ComplianceFieldList.UpdatedBy;
                                complianceFieldType.InputBehaviourId = ComplianceFieldList.InputBehaviourId;
                                complianceFieldType.FileResourceTypeId = ComplianceFieldList.FileResourceTypeId;

                                complianceFieldTypeList.Add(complianceFieldType);
                            }
                            else
                            {
                                CodeResult = StatusCodes.Status404NotFound.ToString();
                                Message = $"input Behaviour Id {ComplianceFieldList.InputBehaviourId} Not Found";
                                Result = false;
                                success = false;
                                break;
                            }
                        }
                        else
                        {
                            CodeResult = StatusCodes.Status404NotFound.ToString();
                            Message = $"File Resource Type Id {ComplianceFieldList.FileResourceTypeId} Not Found";
                            Result = false;
                            success = false;
                            break;
                        }
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"Compliance Field Type Id {ComplianceFieldList.ComplianceFieldTypeId}  Not Found";
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

            ApiResponse<IReadOnlyList<ComplianceFieldType>> response = new ApiResponse<IReadOnlyList<ComplianceFieldType>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceFieldTypeList,
                Success = success
            };

            return response;
        }
    }
}
