using Compliance.Application.Responses;
using MediatR;


namespace Compliance.Application.Features.InputBehaviours.Commands.UpdateBatchInputBehaviours
{
    public class UpdateBatchInputBehavioursListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<UpdateBatchInputBehavioursCommand> ComplainceSourcesList { get; set; }
    }
}
