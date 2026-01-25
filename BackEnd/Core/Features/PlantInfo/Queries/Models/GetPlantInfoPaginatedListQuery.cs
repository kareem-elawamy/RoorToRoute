using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Features.PlantInfo.Queries.Result;
using Core.Wrappers;
using Domain.Enums;
using MediatR;

namespace Core.Features.PlantInfo.Queries.Models
{
    public class GetPlantInfoPaginatedListQuery :IRequest<PaginatedResult<GetPlantInfoPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PlantInfoOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}