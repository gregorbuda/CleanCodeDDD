﻿using Compliance.Api.Utils;
using Compliance.Application.Features.ComplianceSources.Commands.CreateComplianceSources;
using Compliance.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Compliance.Api.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ComplianceSourceController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ComplianceSourceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "complianceSource")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<ApiResponse<int>>> ComplianceSource([FromBody] CreateComplianceSourceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
