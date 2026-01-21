using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos
{
    public class PlantGuideStepRepo : GenericRepositoryAsync<PlantGuideStep>, IPlantGuideStepRepo
    {
        private readonly DbSet<PlantGuideStep> _plantGuideSteps;
        public PlantGuideStepRepo(ApplicationDbContext dbContext) : base(dbContext)
        {
            _plantGuideSteps = dbContext.Set<PlantGuideStep>();
        }

        public async Task<List<PlantGuideStep>> GetAllPlantGuideStepsAsync()
        {
            return await _plantGuideSteps
                            .GroupBy(p => p.StepOrder)
                            .Select(g => g.First())
                            .ToListAsync();
        }

        public async Task<List<PlantGuideStep>> GetPlantGuideStepAsyncByName(string name)
        {
            return await _plantGuideSteps
                            .Include(p => p.PlantInfo)
                            .Where(p => p.PlantInfo!.Name == name)
                            .GroupBy(p => p.StepOrder)
                            .Select(g => g.First())
                            .AsNoTracking()
                            .ToListAsync();
        }

        public async Task<List<PlantGuideStep>> GetPlantGuideStepAsyncByPlantId(Guid plantId)
        {
            return await _plantGuideSteps
                                        .Include(p => p.PlantInfo)
                                        .Where(p => p.PlantInfoId == plantId)
                                        .GroupBy(p => p.StepOrder)
                                        .Select(g => g.First())
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        public async Task<PlantGuideStep> GetPlantGuideStepByIdAsync(Guid id)
        {
            return await _plantGuideSteps.Include(i=>i.PlantInfo).FirstOrDefaultAsync(I => I.Id == id);
        }
    }
}