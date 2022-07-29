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

namespace Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.UpdateBatchComplianceSourceTypeMarket
{
    public class UpdateBatchComplianceSourceTypeMarketCommandHandler : IRequestHandler<UpdateBatchComplianceSourceTypeMarketListCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBatchComplianceSourceTypeMarketCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(UpdateBatchComplianceSourceTypeMarketListCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var ListcomplianceSourceTypeMarket = await Validate(request);

                if (ListcomplianceSourceTypeMarket.Data.Count > 0)
                {

                    _unitOfWork.complianceSourceTypeMarketsRepository.UpdateBatch(ListcomplianceSourceTypeMarket.Data);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = ListcomplianceSourceTypeMarket.CodeResult;
                    Message = ListcomplianceSourceTypeMarket.Message;
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

        public async Task<ApiResponse<IReadOnlyList<ComplianceSourceTypeMarkets>>> Validate(UpdateBatchComplianceSourceTypeMarketListCommand request)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            ComplianceSourceTypes ComplianceSourceTypes = null;
          
            List<ComplianceSourceTypeMarkets> ListcomplianceSourceTypeMarket = new List<ComplianceSourceTypeMarkets>();

            try
            {
                foreach (var ComplianceSourceTypeMarketList in request.ComplainceSourcesTypeMarket)
                {
                    var ComplianceSourceTypeMarketToUpdate = await _unitOfWork.complianceSourceTypeMarketsRepository.GetByIdAsync(ComplianceSourceTypeMarketList.ComplianceSourceTypeMarketId);

                    if (ComplianceSourceTypeMarketToUpdate != null)
                    {
                        ComplianceSourceTypes = await _unitOfWork.complianceSourceTypesRepository.GetByIdAsync(ComplianceSourceTypeMarketList.ComplianceSourceTypeId);

                            if (ComplianceSourceTypes != null)
                            {
                                ComplianceSourceTypeMarkets complianceSourcTypeMarket = new ComplianceSourceTypeMarkets();
                                complianceSourcTypeMarket.ComplianceSourceTypeMarketId = ComplianceSourceTypeMarketList.ComplianceSourceTypeMarketId;
                                complianceSourcTypeMarket.ComplianceSourceTypeId = ComplianceSourceTypeMarketList.ComplianceSourceTypeId;
                                complianceSourcTypeMarket.MarketId = ComplianceSourceTypeMarketList.MarketId;
                                complianceSourcTypeMarket.Status = ComplianceSourceTypeMarketList.Status;
                                complianceSourcTypeMarket.CreatedDate = ComplianceSourceTypeMarketList.CreatedDate;
                                complianceSourcTypeMarket.CreatedBy = ComplianceSourceTypeMarketList.CreatedBy;
                                complianceSourcTypeMarket.UpdatedDate = ComplianceSourceTypeMarketList.UpdatedDate;
                                complianceSourcTypeMarket.UpdatedBy = ComplianceSourceTypeMarketList.UpdatedBy;

                                ListcomplianceSourceTypeMarket.Add(complianceSourcTypeMarket);
                            }
                            else
                            {
                                CodeResult = StatusCodes.Status404NotFound.ToString();
                                Message = $"Compliance Source Types Id {ComplianceSourceTypeMarketList.ComplianceSourceTypeId} Not Found";
                                Result = false;
                                success = false;
                            }                      
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"Compliance Source Type Market Id {ComplianceSourceTypeMarketList.ComplianceSourceTypeMarketId} Not Found";
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

            ApiResponse<IReadOnlyList<ComplianceSourceTypeMarkets>> response = new ApiResponse<IReadOnlyList<ComplianceSourceTypeMarkets>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = ListcomplianceSourceTypeMarket,
                Success = success
            };

            return response;

        }
    }
}
