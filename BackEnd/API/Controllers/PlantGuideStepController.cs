using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Controllers.Shared;
using Core.Base; // عشان كلاس Response<>
using Core.Features.PlantGuideStep.Queries.Result; // عشان الـ DTOs
using Domain.MetaData;
using Microsoft.AspNetCore.Http; // عشان StatusCodes
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations; // عشان التوثيق

namespace API.Controllers
{
    [ApiController]
    public class PlantGuideStepController : BaseApiController
    {
        /// <summary>
        /// جلب جميع خطوات الزراعة
        /// </summary>
        [HttpGet(Router.PlantGuideStep.GetAllPlantGuideSteps)]
        [SwaggerOperation(Summary = "جلب جميع خطوات الزراعة", Description = "يقوم بإرجاع قائمة كاملة بكل خطوات الزراعة المسجلة في النظام.")]
        [SwaggerResponse(StatusCodes.Status200OK, "تم جلب البيانات بنجاح", typeof(Response<List<PlantGuideStepListResponse>>))]
        public async Task<IActionResult> GetAllPlantGuideSteps()
        {
            var response = await Mediator.Send(new Core.Features.PlantGuideStep.Queries.Models.GetAllPlantGuideStepQuery());
            return NewResult(response);
        }

        /// <summary>
        /// جلب خطوات الزراعة لنبات معين (بالـ ID)
        /// </summary>
        [HttpGet(Router.PlantGuideStep.GetPlantGuideStepsByPlantId)]
        [SwaggerOperation(Summary = "جلب خطوات الزراعة لنبات معين (ID)", Description = "يقوم بإرجاع بيانات النبات الأساسية (الاسم، التربة، الخ) ومعها قائمة بجميع خطوات زراعته.")]
        [SwaggerResponse(StatusCodes.Status200OK, "تم العثور على البيانات", typeof(Response<GetPlantGuideStepByPlantIdResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "النبات غير موجود أو ليس له خطوات")]
        public async Task<IActionResult> GetPlantGuideStepsByPlantId([FromRoute] Guid id)
        {
            var response = await Mediator.Send(new Core.Features.PlantGuideStep.Queries.Models.GetPlantGuideStepByPlantIdQueries(id));
            return NewResult(response);
        }

        /// <summary>
        /// البحث عن خطوات زراعة باستخدام اسم النبات
        /// </summary>
        [HttpGet(Router.PlantGuideStep.GetPlantGuideStepsByPlantName)]
        [SwaggerOperation(Summary = "البحث عن خطوات زراعة بالاسم", Description = "يبحث عن النبات بالاسم ويرجع تفاصيله وخطوات زراعته.")]
        [SwaggerResponse(StatusCodes.Status200OK, "تم العثور على البيانات", typeof(Response<GetPlantGuideStepByPlantIdResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "لم يتم العثور على نبات بهذا الاسم")]
        public async Task<IActionResult> GetPlantGuideStepsByPlantName([FromRoute] string plantName)
        {
            var response = await Mediator.Send(new Core.Features.PlantGuideStep.Queries.Models.GetPlantGuideStepByPlantNameQuerie(plantName));
            return NewResult(response);
        }

        /// <summary>
        /// جلب تفاصيل خطوة واحدة محددة
        /// </summary>
        [HttpGet(Router.PlantGuideStep.GetPlantGuideStepById)]
        [SwaggerOperation(Summary = "جلب تفاصيل خطوة واحدة (Step ID)", Description = "يقوم بإرجاع بيانات خطوة زراعة واحدة فقط باستخدام المعرف الخاص بها.")]
        [SwaggerResponse(StatusCodes.Status200OK, "تم العثور على الخطوة", typeof(Response<PlantGuideStepListResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "الخطوة غير موجودة")]
        public async Task<IActionResult> GetPlantGuideStepById([FromRoute] Guid id)
        {
            var response = await Mediator.Send(new Core.Features.PlantGuideStep.Queries.Models.GetPlantGuideStepByIdQuery(id));
            return NewResult(response);
        }
    }
}