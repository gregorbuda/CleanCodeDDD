using Compliance.Api.Utils;
using Compliance.Application.Features.InputBehaviours.Commands.CreateInputBehaviours;
using Compliance.Application.Features.InputBehaviours.Commands.DeleteInputBehaviours;
using Compliance.Application.Features.InputBehaviours.Commands.UpdateInputBehaviours;
using Compliance.Application.Features.InputBehaviours.Queries;
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
    [SwaggerTag("The Input Behaviours REST services")]
    public class InputBehaviourController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public InputBehaviourController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Input Behaviour
        /// </summary>
        /// <param name="command">The data Input Behaviour.</param>
        /// <returns>
        /// An Input Behaviour Id 
        /// </returns>
        /// <remarks>
        /// Create Input Behaviour.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPost()]
        [ProducesResponseType(typeof(ApiResponse<InputBehaviourCreateResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<InputBehaviourCreateResponse>>> CreateInputBehaviour([FromBody] CreateInputBehavioursCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Input Behaviour All
        /// </summary>
        /// <param></param>
        /// <returns>
        /// A List of Input Behaviour
        /// </returns>
        /// <remarks>
        /// Get Input Behaviour All.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("InputBehaviourAll")]
        [ProducesResponseType(typeof(ApiResponse<IReadOnlyList<InputBehaviourResponse>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<InputBehaviourResponse>>>> GetInputBehaviourAll()
        {
            var query = new GetInputBehavioursAllList();
            var test = await _mediator.Send(query);
            return Ok(test);
        }

        /// <summary>
        /// Update Input Behaviour
        /// </summary>
        /// <param name="command">The data Input Behaviour.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Update Input Behaviour.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpPut()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> UpdateInputBehaviour([FromBody] UpdateInputBehavioursCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Delete Input Behaviour
        /// </summary>
        /// <param name="command">The data Input Behaviour.</param>
        /// <returns>
        /// A Boolean
        /// </returns>
        /// <remarks>
        /// Delete Input Behaviour.\
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpDelete()]
        [ProducesResponseType(typeof(ApiResponse<Boolean>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<Boolean>>> DeleteInputBehaviour([FromBody] DeleteInputBehavioursCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Get Input Behaviour By Id
        /// </summary>
        /// <param name="InputBehaviourId">The Input Behaviour Id.</param>
        /// <returns>
        /// A Input Behaviour By Id 
        /// </returns>
        /// <remarks>
        /// Get Input Behaviour By Id
        /// `Note: This endpoint requires authentication.` [more info](#section/Authentication)
        /// </remarks>
        [HttpGet("InputBehaviourById")]
        [ProducesResponseType(typeof(ApiResponse<InputBehaviourResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<InputBehaviourResponse>>> GetInputBehaviourById(Int32 InputBehaviourId)
        {
            var query = new GetInputBehavioursByIdList(InputBehaviourId);
            var test = await _mediator.Send(query);
            return Ok(test);
        }

    }
}
