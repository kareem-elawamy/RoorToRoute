using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Features.PlantGuideStep.Queries.Result;
using MediatR;

namespace Core.Features.PlantGuideStep.Queries.Models
{
    public class GetPlantGuideStepByPlantIdQueries : IRequest<Response<GetPlantGuideStepByPlantIdResponse>>
    {
        public Guid Id { get; set; }
        public GetPlantGuideStepByPlantIdQueries(Guid id)
        {
            Id = id;
        }

    }
}