using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Compliance.Api.Controller
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v1/[controller]")]
    [SwaggerTag("The Addresses REST services")]
    public class ComplianceSourceController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceSourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<int>>> ComplianceSource([FromBody] CreateComplianceSourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
