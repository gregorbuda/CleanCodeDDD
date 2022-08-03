
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.InputBehaviours.Queries
{
    public class GetInputBehavioursByIdList : IRequest<ApiResponse<InputBehaviourResponse>>
    {
        public Int32 _inputBehaviourId { get; set; }

        public GetInputBehavioursByIdList(Int32 InputBehaviourId)
        {
            _inputBehaviourId = InputBehaviourId;
        }
    }
}
