using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;

namespace Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources
{
    public class CreateComplianceSourceCommandHandler : IRequestHandler<CreateComplianceSourceCommand, ApiResponse<Int32>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateComplianceSourceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Int32>> Handle(CreateComplianceSourceCommand request, CancellationToken cancellationToken)
        {
            var complianceSourceEntity = _mapper.Map<ComplianceSource>(request);

            int Result;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                _unitOfWork.complianceSourceRepository.AddEntity(complianceSourceEntity);

                var result = await _unitOfWork.Complete();

                if (result > 0)
                {
                    CodeResult = "200";
                    Message = "Success, and there is a response body.";
                    Result = complianceSourceEntity.ComplianceSourceId;
                    success = true;
                }
                else
                {
                    CodeResult = "400";
                    Message = "No se pudo registrar el ComplianceSource";
                    Result = 0;
                    success = false;
                }

            }
            catch (Exception ex)
            {
                CodeResult = "500";
                Message = "Server Error";
                Result = 0;
                success = false;
            }

            ApiResponse<Int32> response = new ApiResponse<Int32>
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
