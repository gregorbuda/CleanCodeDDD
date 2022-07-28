using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceDistributorsData.Commands.CreateBatchComplianceDistributorData;
using Compliance.Application.Features.ComplianceDistributorsData.Commands.UpdateBatchComplianceDistributorsData;
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
    [SwaggerTag("The Compliance Field Type REST services")]
    public class ComplianceDistributorDataController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceDistributorDataController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Batch Compliance Compliance Distributor Data
        /// </summary>
        /// <param name="command">The data Input Compliance Distributor Data.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Create Batch Compliance Compliance Distributor Data
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> CreateBatchComplianceDistributorData([FromBody] CreateBatchComplianceDistributorDataListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Update Batch Compliance Compliance Distributor Data
        /// </summary>
        /// <param name="command">The data Input Compliance Distributor Data.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update Batch Compliance Compliance Distributor Data
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut("Batch")]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateBatchComplianceDistributorData([FromBody] UpdateBatchComplianceDistributorsDataListCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
