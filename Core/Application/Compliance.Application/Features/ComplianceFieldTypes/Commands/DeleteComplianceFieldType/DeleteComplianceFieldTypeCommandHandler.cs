using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Compliance.Application.Features.ComplianceFieldTypes.Commands.DeleteComplianceFieldType
{
    /// <summary>
    /// Delete Compliance Field Type Command Handler
    /// </summary>
    public class DeleteComplianceFieldTypeCommandHandler : IRequestHandler<DeleteComplianceFieldTypeCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteComplianceFieldTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteComplianceFieldTypeCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var ComplianceSourceToDelete = await _unitOfWork.complianceFieldTypeRepository.GetByIdAsync(request.ComplianceFieldTypeId);

                if (ComplianceSourceToDelete != null)
                {
                    _unitOfWork.complianceFieldTypeRepository.Delete(ComplianceSourceToDelete.ComplianceFieldTypeId);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Field Type Not Found";
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
    }
}
