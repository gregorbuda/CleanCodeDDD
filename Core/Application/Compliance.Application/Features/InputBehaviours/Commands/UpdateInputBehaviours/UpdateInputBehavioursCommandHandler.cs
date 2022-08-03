using AutoMapper;
using Compliance.Application.Contracts.Persistence;

using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.InputBehaviours.Commands.UpdateInputBehaviours
{
    /// <summary>
    /// Update  Input Behaviours Command Handler
    /// </summary>
    public class UpdateInputBehavioursCommandHandler : IRequestHandler<UpdateInputBehavioursCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInputBehavioursCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<Boolean>> Handle(UpdateInputBehavioursCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var InputBehaviourToUpdate = await _unitOfWork.inputBehaviourRepository.GetByIdAsync(request.InputBehaviourId);

                if (InputBehaviourToUpdate != null)
                {
                    //_mapper.Map(request, InputBehaviourToUpdate, typeof(UpdateInputBehavioursCommand), typeof(InputBehaviour));

                    _unitOfWork.inputBehaviourRepository.UpdateEntity(InputBehaviourToUpdate);

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
    }
}
