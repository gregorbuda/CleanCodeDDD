﻿using AutoMapper;
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

namespace Compliance.Application.Features.ComplianceSources.Commands.UpdateComplianceSources
{
    public class UpdateComplianceSourceCommandHandler : IRequestHandler<UpdateComplianceSourceCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateComplianceSourceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(UpdateComplianceSourceCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var ComplianceSourceToUpdate = await _unitOfWork.complianceSourceRepository.GetByIdAsync(request.ComplianceSourceId);

                if (ComplianceSourceToUpdate != null)
                {
                    _mapper.Map(request, ComplianceSourceToUpdate, typeof(UpdateComplianceSourceCommand), typeof(ComplianceSource));

                    _unitOfWork.complianceSourceRepository.UpdateEntity(ComplianceSourceToUpdate);

                    await _unitOfWork.Complete();

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Compliance Source Not Found";
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
