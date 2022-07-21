using Compliance.Api.Utils;
using Compliance.Application.Features.InputBehaviours.Commands.CreateInputBehaviours;
using Compliance.Application.Features.InputBehaviours.Queries;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Compliance.Api.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InputBehaviourController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public InputBehaviourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<InputBehaviourCreateResponse>>> CreateComplianceSource([FromBody] CreateInputBehavioursCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetInputBehaviourAll")]
        [ProducesResponseType(typeof(InputBehaviourResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<InputBehaviourResponse>>>> GetInputBehaviourAll()
        {
            var query = new GetInputBehavioursAllList();
            var test = await _mediator.Send(query);
            return Ok(test);
        }
    }
}
