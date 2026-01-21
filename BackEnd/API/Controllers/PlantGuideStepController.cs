using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Shared;
using Domain.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class PlantGuideStepController : BaseApiController
    {
        [HttpGet(Router.PlantGuideStep.GetAllPlantGuideSteps)]
        public async Task<IActionResult> GetAllPlantGuideSteps()
        {
            var response = await Mediator.Send(new Core.Features.PlantGuideStep.Queries.Models.GetAllPlantGuideStepQuery());
            return NewResult(response);
        }
        [HttpGet(Router.PlantGuideStep.GetPlantGuideStepsByPlantId)]
        public async Task<IActionResult> GetPlantGuideStepsByPlantId([FromRoute] Guid id)
        {
            var response = await Mediator.Send(new Core.Features.PlantGuideStep.Queries.Models.GetPlantGuideStepByPlantIdQueries(id));
            return NewResult(response);
        }
        [HttpGet(Router.PlantGuideStep.GetPlantGuideStepsByPlantName)]
        public async Task<IActionResult> GetPlantGuideStepsByPlantName([FromRoute] string plantName)
        {
            var response = await Mediator.Send(new Core.Features.PlantGuideStep.Queries.Models.GetPlantGuideStepByPlantNameQuerie(plantName));
            return NewResult(response);
        }
        [HttpGet(Router.PlantGuideStep.GetPlantGuideStepById)]
        public async Task<IActionResult> GetPlantGuideStepById([FromRoute] Guid id)
        {
            var response = await Mediator.Send(new Core.Features.PlantGuideStep.Queries.Models.GetPlantGuideStepByIdQuery(id));
            return NewResult(response);
        }


    }
}