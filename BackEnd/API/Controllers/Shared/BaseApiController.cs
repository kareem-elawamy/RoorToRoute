using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Shared
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        //     
    }
}