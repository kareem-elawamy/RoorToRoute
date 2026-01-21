using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Base;
using Core.Features.PlantGuideStep.Queries.Models;
using Core.Features.PlantGuideStep.Queries.Result;
using MediatR;
using Service.Abstract;

namespace Core.Features.PlantGuideStep.Queries.Handler
{
    public class PlantGuideStepHandler : ResponseHandler,
      IRequestHandler<GetAllPlantGuideStepQuery, Response<List<PlantGuideStepListResponse>>>,
      IRequestHandler<GetPlantGuideStepByIdQuery, Response<PlantGuideStepListResponse>>,
      // 👇 تم تصحيح النوع هنا من Query إلى Response
      IRequestHandler<GetPlantGuideStepByPlantIdQueries, Response<GetPlantGuideStepByPlantIdResponse>>,
      IRequestHandler<GetPlantGuideStepByPlantNameQuerie, Response<GetPlantGuideStepByPlantIdResponse>>
    {
        private readonly IPlantGuideStepService _plantGuideStepService;
        private readonly IMapper _mapper;

        public PlantGuideStepHandler(IPlantGuideStepService plantGuideStepService, IMapper mapper)
        {
            _plantGuideStepService = plantGuideStepService;
            _mapper = mapper;
        }

        // Get All
        public async Task<Response<List<PlantGuideStepListResponse>>> Handle(GetAllPlantGuideStepQuery request, CancellationToken cancellationToken)
        {
            var result = await _plantGuideStepService.GetAllPlantGuideStepsAsync();
            var mapped = _mapper.Map<List<PlantGuideStepListResponse>>(result);
            return Success(mapped);
        }

        // Get By ID (Single)
        public async Task<Response<PlantGuideStepListResponse>> Handle(GetPlantGuideStepByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _plantGuideStepService.GetPlantGuideStepByIdAsync(request.Id);
            if (result == null) return NotFound<PlantGuideStepListResponse>();

            var mapped = _mapper.Map<PlantGuideStepListResponse>(result);
            return Success(mapped);
        }

        // Get By Plant ID
        public async Task<Response<GetPlantGuideStepByPlantIdResponse>> Handle(GetPlantGuideStepByPlantIdQueries request, CancellationToken cancellationToken)
        {
            var stepsList = await _plantGuideStepService.GetPlantGuideStepAsyncByPlantId(request.Id);

            if (stepsList == null || !stepsList.Any())
                return NotFound<GetPlantGuideStepByPlantIdResponse>("No steps found.");

            var plantInfo = stepsList.First().PlantInfo;

            var response = new GetPlantGuideStepByPlantIdResponse
            {
                PlantId = plantInfo.Id,
                PlantInfoName = plantInfo.Name,
                PlantInfoScientificName = plantInfo.ScientificName,
                PlantInfoIdealSoil = plantInfo.IdealSoil,
                Steps = _mapper.Map<List<PlantGuideStepListResponse>>(stepsList)
            };

            return Success(response);
        }

        // Get By Plant Name (List)
        // Get By Plant Name
        public async Task<Response<GetPlantGuideStepByPlantIdResponse>> Handle(GetPlantGuideStepByPlantNameQuerie request, CancellationToken cancellationToken)
        {
            // 1. جلب القائمة من السيرفيس
            var stepsList = await _plantGuideStepService.GetPlantGuideStepAsyncByPlantName(request.PlantName);

            // 2. التحقق إن القائمة مش فاضية
            if (stepsList == null || !stepsList.Any())
                return NotFound<GetPlantGuideStepByPlantIdResponse>("No steps found for this plant.");

            // 3. استخراج بيانات النبات من أول خطوة (بما أننا عملنا Include في الـ Repo)
            // لاحظ: نفترض أن الـ Repo عامل Include للـ PlantInfo
            var plantInfo = stepsList.First().PlantInfo;

            // 4. بناء الـ Response يدوياً لضمان الدقة
            var response = new GetPlantGuideStepByPlantIdResponse
            {
                PlantId = plantInfo.Id,
                PlantInfoName = plantInfo.Name,
                PlantInfoScientificName = plantInfo.ScientificName,
                PlantInfoIdealSoil = plantInfo.IdealSoil,

                // هنا بنحول قائمة الخطوات باستخدام المابينج اللي عملناه للعنصر الصغير
                Steps = _mapper.Map<List<PlantGuideStepListResponse>>(stepsList)
            };

            return Success(response);
        }
    }
}