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

namespace Compliance.Application.Features.InputBehaviours.Queries
{
    public class GetInputBehavioursByIdListHandler : IRequestHandler<GetInputBehavioursByIdList, ApiResponse<InputBehaviourResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInputBehavioursByIdListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<InputBehaviourResponse>> Handle(GetInputBehavioursByIdList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            InputBehaviour inputBehaviour = null;
            InputBehaviourResponse inputBehaviourResponse = null;
            String CodeResult = "";

            try
            {
                inputBehaviour = await _unitOfWork.inputBehaviourRepository.GetByIdAsync(request._inputBehaviourId);

                inputBehaviourResponse = _mapper.Map<InputBehaviourResponse>(inputBehaviour);

                if (inputBehaviour.InputBehaviourId > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = $"input Behaviour Id {request._inputBehaviourId} Not Found";
                    inputBehaviour = null;
                    success = false;
                }
            }
            catch (Exception ex)
            {
                CodeResult = StatusCodes.Status500InternalServerError.ToString();
                Message = "Internal Server Error";
                inputBehaviour = null;
                success = false;
            }

            ApiResponse<InputBehaviourResponse> response = new ApiResponse<InputBehaviourResponse>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = inputBehaviourResponse,
                Success = success
            };

            return response;
        }
    }
}
