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

namespace Compliance.Application.Features.InputBehaviours.Commands.CreateInputBehaviours
{
    /// <summary>
    /// Create Input Behaviours Command Handler
    /// </summary>
    public class CreateInputBehavioursCommandHandler : IRequestHandler<CreateInputBehavioursCommand, ApiResponse<InputBehaviourCreateResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInputBehavioursCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<InputBehaviourCreateResponse>> Handle(CreateInputBehavioursCommand request, CancellationToken cancellationToken)
        {
            var complianceSourceEntity = _mapper.Map<InputBehaviour>(request);

            InputBehaviour inputBehaviour = null;
            InputBehaviourCreateResponse objReponse = null;
            Boolean success = false;
            String Message = "";
            String CodeResult = "";

            try
            {
                inputBehaviour = await _unitOfWork.inputBehaviourRepository.AddAsync(complianceSourceEntity);

                objReponse = _mapper.Map<InputBehaviourCreateResponse>(inputBehaviour);

                if (inputBehaviour.InputBehaviourId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status400BadRequest.ToString();
                    Message = "No se pudo registrar el ComplianceSource";
                    inputBehaviour = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                success = false;
                inputBehaviour = null;
            }

            ApiResponse<InputBehaviourCreateResponse> response = new ApiResponse<InputBehaviourCreateResponse>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = objReponse,
                Success = success
            };

            return response;
        }
    }
}
