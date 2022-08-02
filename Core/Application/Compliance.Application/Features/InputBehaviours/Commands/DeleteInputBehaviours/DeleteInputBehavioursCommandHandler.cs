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

namespace Compliance.Application.Features.InputBehaviours.Commands.DeleteInputBehaviours
{
    public class DeleteInputBehavioursCommandHandler : IRequestHandler<DeleteInputBehavioursCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInputBehavioursCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(DeleteInputBehavioursCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var InputBehaviourToDelete = await _unitOfWork.inputBehaviourRepository.GetByIdAsync(request.InputBehaviourId);

                if (InputBehaviourToDelete != null)
                {
                    var ListcomplianceSourceTypes = Validate(request.InputBehaviourId);

                    if (ListcomplianceSourceTypes != null)
                    {
                        _unitOfWork.complianceSourceTypesRepository.DeleteBatch((IEnumerable<ComplianceSourceTypes>)ListcomplianceSourceTypes);
                    }

                    var complianceFieldTypeList = _unitOfWork.complianceFieldTypeRepository.GetComplianceFieldTypeByInputBehaviourId(request.InputBehaviourId);

                    if (complianceFieldTypeList != null)
                    {
                        _unitOfWork.complianceFieldTypeRepository.DeleteBatch((IEnumerable<ComplianceFieldType>)complianceFieldTypeList);
                    }

                    _unitOfWork.inputBehaviourRepository.DeleteEntity(InputBehaviourToDelete);

                    await _unitOfWork.Complete();

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Input Behaviour Not Found";
                    Result = false;
                    success = false;
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

        public async Task<ApiResponse<IReadOnlyList<ComplianceSourceTypes>>> Validate(Int32 InputBehaviourId)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            List<ComplianceSourceTypes> complianceSourceTypeListToDelete = new List<ComplianceSourceTypes>();
            List<ComplianceFieldType> complianceFieldTypeList = new List<ComplianceFieldType>();

            try
            {
                complianceFieldTypeList = _unitOfWork.complianceFieldTypeRepository.GetComplianceFieldTypeByInputBehaviourId(InputBehaviourId);

                foreach (var ListComplianceSourceType in complianceFieldTypeList)
                {
                    ComplianceSourceTypes complianceSourceTypes = new ComplianceSourceTypes();
                    complianceSourceTypes = _unitOfWork.complianceSourceTypesRepository.GetComplianceSourceTypeByComplianceFileTypeId(ListComplianceSourceType.ComplianceFieldTypeId);
                    complianceSourceTypeListToDelete.Add(complianceSourceTypes);
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
                Data = complianceSourceTypeListToDelete,
                Success = success
            };

            return response;
        }
    }
}
