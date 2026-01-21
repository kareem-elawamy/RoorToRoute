using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class PlantGuideStepService : IPlantGuideStepService
    {
        private readonly IPlantGuideStepRepo _plantGuideStepRepo;
        public PlantGuideStepService(IPlantGuideStepRepo plantGuideStepRepo)
        {
            _plantGuideStepRepo = plantGuideStepRepo;
        }
        public async Task<List<PlantGuideStep>> GetAllPlantGuideStepsAsync()
        {
            return await _plantGuideStepRepo.GetAllPlantGuideStepsAsync();
        }

        public async Task<List<PlantGuideStep>> GetPlantGuideStepAsyncByPlantName(string name)
        {
            return await _plantGuideStepRepo.GetPlantGuideStepAsyncByName(name);
        }

        public Task<List<PlantGuideStep>> GetPlantGuideStepAsyncByPlantId(Guid plantId)
        {
            return _plantGuideStepRepo.GetPlantGuideStepAsyncByPlantId(plantId);
        }

        public Task<PlantGuideStep> GetPlantGuideStepByIdAsync(Guid id)
        {
            return _plantGuideStepRepo.GetPlantGuideStepByIdAsync(id);
        }
    }
}