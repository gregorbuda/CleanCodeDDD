using AutoMapper;
using Compliance.Application.Contracts.Persistence;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Compliance.Application.Features.InputBehaviours.Commands.UpdateBatchInputBehaviours
{
    public class UpdateBatchInputBehavioursCommandHandler : IRequestHandler<UpdateBatchInputBehavioursListCommand, ApiResponse<Boolean>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBatchInputBehavioursCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  async Task<ApiResponse<Boolean>> Handle(UpdateBatchInputBehavioursListCommand request, CancellationToken cancellationToken)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
            try
            {
                var ListinputBehaviour = await Validate(request);

                if (ListinputBehaviour.Data.Count > 0)
                {

                    _unitOfWork.inputBehaviourRepository.UpdateBatch(ListinputBehaviour.Data);

                    CodeResult = StatusCodes.Status200OK.ToString();
                    Message = "Success, and there is a response body.";
                    success = true;
                    Result = true;
                }
                else
                {
                    CodeResult = ListinputBehaviour.CodeResult;
                    Message = ListinputBehaviour.Message;
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

        public async Task<ApiResponse<IReadOnlyList<InputBehaviour>>> Validate(UpdateBatchInputBehavioursListCommand request)
        {
            Boolean success = false;
            String Message = "";
            String CodeResult = "";
            Boolean Result = false;
           
            List<InputBehaviour> inputBehavioursList = new List<InputBehaviour>();

            try
            {
                foreach (var ListinputBehaviours in request.ComplainceSourcesList)
                {
                    var inputBehavioursToUpdate = await _unitOfWork.inputBehaviourRepository.GetByIdAsync(ListinputBehaviours.InputBehaviourId);

                    if (inputBehavioursToUpdate != null)
                    {
                        InputBehaviour inputBehaviours = new InputBehaviour();
                        inputBehaviours.InputBehaviourId = ListinputBehaviours.InputBehaviourId;
                        inputBehaviours.InputBehaviourName = ListinputBehaviours.InputBehaviourName;
                        inputBehaviours.Status = ListinputBehaviours.Status;
                        inputBehaviours.CreatedDate = ListinputBehaviours.CreatedDate;
                        inputBehaviours.CreatedBy = ListinputBehaviours.CreatedBy;
                        inputBehaviours.UpdatedDate = ListinputBehaviours.UpdatedDate;
                        inputBehaviours.UpdatedBy = ListinputBehaviours.UpdatedBy;

                        inputBehavioursList.Add(inputBehaviours);
                    }
                    else
                    {
                        CodeResult = StatusCodes.Status404NotFound.ToString();
                        Message = $"Input Behaviour Id {ListinputBehaviours.InputBehaviourId}  Not Found";
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

            ApiResponse<IReadOnlyList<InputBehaviour>> response = new ApiResponse<IReadOnlyList<InputBehaviour>>
            {
                CodeResult = CodeResult,
                Message = Message,
                Data = inputBehavioursList,
                Success = success
            };

            return response;

        }
    }
}
