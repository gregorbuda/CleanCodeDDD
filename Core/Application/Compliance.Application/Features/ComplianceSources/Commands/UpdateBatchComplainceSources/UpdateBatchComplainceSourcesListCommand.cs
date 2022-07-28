using Compliance.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compliance.Application.Features.ComplianceSources.Commands.UpdateBatchComplainceSources
{
    public  class UpdateBatchComplainceSourcesListCommand : IRequest<ApiResponse<Boolean>>
    {
        public List<UpdateBatchComplainceSourcesCommand> ComplainceSourcesList { get; set; }
    }
}
