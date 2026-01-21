
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Features.PlantGuideStep.Queries.Result
{
    public class GetPlantGuideStepByPlantIdResponse
    {
        public Guid PlantId { get; set; }
        
        public string? PlantInfoName { get; set; }
        public string? PlantInfoScientificName { get; set; }
        public string? PlantInfoIdealSoil { get; set; }
        public List<PlantGuideStepListResponse>? Steps { get; set; }
        
    }
}