using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Controllers.Shared;
using Core.Features.OrganizationRole.Commands.Models;
using Domain.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class OrganizationRoleController : BaseApiController
    {
        [HttpPost(Router.OrganizationRole.CreateOrganizationRole)]
        public async Task<IActionResult> CreateOrganizationRole([FromForm] AddOrganizationRoleCommand command)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null) return Unauthorized();

            // نمرر هوية المستخدم للكوماند
            command.RequesterUserId = Guid.Parse(userIdString);

            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}