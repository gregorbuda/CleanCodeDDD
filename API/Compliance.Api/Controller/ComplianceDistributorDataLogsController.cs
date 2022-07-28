using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceDistributorDataLogsBls.Commands.CreateBatchComplianceDistributorDataLogsBls;
using Compliance.Application.Responses;
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
    [SwaggerTag("The Compliance Distributor Data Logs REST services")]
    public class ComplianceDistributorDataLogsController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceDistributorDataLogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Batch Compliance Compliance Distributor Data Logs
        /// </summary>
        /// <param name="command">The data Input Compliance Distributor Data Logs.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Create Batch Compliance Compliance Distributor Data Logs
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> CreateBatchComplianceDistributorDataLogs([FromBody] CreateBatchComplianceDistributorDataLogsBlsListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
