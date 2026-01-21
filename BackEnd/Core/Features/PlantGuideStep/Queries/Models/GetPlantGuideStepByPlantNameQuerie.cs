using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Features.PlantGuideStep.Queries.Result;
using MediatR;

namespace Core.Features.PlantGuideStep.Queries.Models
{
    public class GetPlantGuideStepByPlantNameQuerie : IRequest<Response<GetPlantGuideStepByPlantIdResponse>>
    {
        public string PlantName { get; set; }
        public GetPlantGuideStepByPlantNameQuerie(string plantName)
        {
            PlantName = plantName;
        }

    }
}