using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.ComplianceSources.Commands.UpdateBatchComplainceSources
{
    public class UpdateBatchComplainceSourcesCommandHandler : IRequestHandler<UpdateBatchComplainceSourcesListCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBatchComplainceSourcesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(UpdateBatchComplainceSourcesListCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var ListcomplianceSource = await Validate(request);

                if (ListcomplianceSource.Data.Count > 0)
                {

                    _unitOfWork.complianceSourceRepository.UpdateBatch(ListcomplianceSource.Data);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = ListcomplianceSource.CodeResult;
                    Message = ListcomplianceSource.Message;
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

        public async Task<ApiResponse<IReadOnlyList<ComplianceSource>>> Validate(UpdateBatchComplainceSourcesListCommand request)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
        
            List<ComplianceSource> complianceSourceList = new List<ComplianceSource>();

            try
            {
                foreach (var ComplianceSourceList in request.ComplainceSourcesList)
                {
                    var ComplianceSourceToUpdate = await _unitOfWork.complianceSourceRepository.GetByIdAsync(ComplianceSourceList.ComplianceSourceId);

                    if (ComplianceSourceToUpdate != null)
                    {
                        ComplianceSource complianceSource = new ComplianceSource();
                        complianceSource.ComplianceSourceId = ComplianceSourceList.ComplianceSourceId;
                        complianceSource.ComplianceSourceName = ComplianceSourceList.ComplianceSourceName;
                        complianceSource.Status = ComplianceSourceList.Status;
                        complianceSource.CreatedDate = ComplianceSourceList.CreatedDate;
                        complianceSource.CreatedBy = ComplianceSourceList.CreatedBy;
                        complianceSource.UpdatedDate = ComplianceSourceList.UpdatedDate;
                        complianceSource.UpdatedBy = ComplianceSourceList.UpdatedBy;

                        complianceSourceList.Add(complianceSource);
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"Compliance Source Id {ComplianceSourceList.ComplianceSourceId}  Not Found";
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

            ApiResponse<IReadOnlyList<ComplianceSource>> response = new ApiResponse<IReadOnlyList<ComplianceSource>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = complianceSourceList,
                Success = success
            };

            return response;

        }
    }
}
