using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Features.PlantGuideStep.Queries.Result
{
    public class PlantGuideStepListResponse
    {
        public Guid Id { get; set; }
        public int StepOrder { get; set; }
        public string? Title { get; set; }
        public string? Instruction { get; set; }
    }
}