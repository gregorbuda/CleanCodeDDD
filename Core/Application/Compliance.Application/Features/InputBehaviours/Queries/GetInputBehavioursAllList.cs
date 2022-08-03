
using Compliance.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.InputBehaviours.Queries
{
    public class GetInputBehavioursAllList : IRequest<ApiResponse<IReadOnlyList<InputBehaviour>>>
    {
    }
}
