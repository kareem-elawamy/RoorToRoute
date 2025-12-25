using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Shared
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }

            return BadRequest(new
            {
                result.Error.Code,
                result.Error.Description
            });

        }
        protected IActionResult HandleResult(Result result)
        {
            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(new
            {
                result.Error.Code,
                result.Error.Description
            });
        }
    }
}