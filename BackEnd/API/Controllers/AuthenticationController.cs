using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Shared;
using Core.Features.authentication.Commands.Models;
using Domain.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseApiController
    {
        [HttpPost(Router.Authentication.Regsiter)]
        public async Task<IActionResult> Regsiter([FromForm] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}