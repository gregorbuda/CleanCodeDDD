using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceSourceTypeMarket.Commands.CreateComplianceSourceTypeMarket;
using Compliance.Application.Responses;
using Compliance.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Compliance.Api.Controller
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    [ProducesResponseType(typeof(ProblemDetailsBadRequest), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ProblemDetailsNotFound), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProblemDetailsNotAcceptable), (int)HttpStatusCode.NotAcceptable)]
    [ProducesResponseType(typeof(ProblemDetailsInternalServerError), (int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetailsUnauthorized), (int)HttpStatusCode.Unauthorized)]
    [SwaggerTag("The Compliance Source Type Markets REST services")]
    public class ComplianceSourceTypeMarketsController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceSourceTypeMarketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Compliance Source Type Markets
        /// </summary>
        /// <param name="command">The data Compliance Source Type Markets.</param>
        /// <returns>
        /// A Compliance Source Type Markets Id 
        /// </returns>
        /// <remarks>
        /// Create Compliance Source Type Markets
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<ComplianceSourceTypeMarketsCreateResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<ComplianceSourceTypeMarketsCreateResponse>>> CreateComplianceSourceTypeMarkets([FromBody] CreateComplianceSourceTypeMarketCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
