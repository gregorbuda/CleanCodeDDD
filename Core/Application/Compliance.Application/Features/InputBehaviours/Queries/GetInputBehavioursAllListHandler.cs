﻿using AutoMapper;
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
    public class GetInputBehavioursAllListHandler : IRequestHandler<GetInputBehavioursAllList, ApiResponse<IReadOnlyList<InputBehaviour>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInputBehavioursAllListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IReadOnlyList<InputBehaviour>>> Handle(GetInputBehavioursAllList request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            IReadOnlyList<InputBehaviour> inputBehaviour = null;
            //IReadOnlyList<InputBehaviourResponse> inputBehaviourResponse = null;
            String CodeResult = "";

            try
            {
                inputBehaviour = await _unitOfWork.inputBehaviourRepository.GetAllAsync();

               // inputBehaviourResponse = _mapper.Map<IReadOnlyList<InputBehaviour>>(inputBehaviour);

                if (inputBehaviour.Count > 0)
                {
                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                }
                else
                {
                    CodeResult = StatusCodes.Status404NotFound.ToString();
                    Message = "Input Behaviour Not Found";
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

            ApiResponse<IReadOnlyList<InputBehaviour>> response = new ApiResponse<IReadOnlyList<InputBehaviour>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = inputBehaviour,
                Success = success
            };

            return response;
        }
    }
}
