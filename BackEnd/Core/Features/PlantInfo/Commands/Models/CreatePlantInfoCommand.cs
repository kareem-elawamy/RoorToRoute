using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Features.PlantInfo.Commands.Models
{
    public class CreatePlantInfoCommand : IRequest<Response<string>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }
        public string? IdealSoil { get; set; }
        public string? PlantingSeason { get; set; }
        public string? ScientificName { get; set; }
        public string? MedicalBenefits { get; set; }

    }
}