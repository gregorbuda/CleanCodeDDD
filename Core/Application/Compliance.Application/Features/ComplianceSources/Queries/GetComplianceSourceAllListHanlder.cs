using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;


namespace Compliance.Application.Features.ComplianceSources.Queries
{
    /// <summary>
    /// Get Compliance Source All List Hanlder
    /// </summary>
    public class GetComplianceSourceAllListHanlder : IRequestHandler<GetComplianceSourceAllList, ApiResponse<IReadOnlyList<ComplianceSource>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetComplianceSourceAllListHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<ComplianceSource>>> Handle(GetComplianceSourceAllList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<ComplianceSource> ComplianceSource = null;
            IReadOnlyList<ComplianceSourceResponse> ComplianceSourceResponseList = new List<ComplianceSourceResponse>();
       
            String CodeResult = "";

            try
            {
                ComplianceSource = await _unitOfWork.complianceSourceRepository.GetAllAsync();

                if (ComplianceSource.Count > 0)
                {
                    //ComplianceSourceResponseList = _mapper.Map<IReadOnlyList<ComplianceSourceResponse>>(ComplianceSource);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Source Not Found";
                    ComplianceSource = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                ComplianceSource = null;
                success = false;
            }

            ApiResponse<IReadOnlyList<ComplianceSource>> response = new ApiResponse<IReadOnlyList<ComplianceSource>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ComplianceSource,
                Success = success
            };

            return response;
        }
    }
}
