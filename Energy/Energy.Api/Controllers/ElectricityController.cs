using Energy.Api.Controllers;
using Energy.Common.IncomeModels.Base;
using Microsoft.AspNetCore.Mvc;
using Energy.Common.IncomeModels.Electricity;
using Energy.Services.Interfaces;

namespace Energy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ElectricityController : BaseController
    {
        private readonly IElectricityService _electricityService;

        public ElectricityController(IElectricityService electricityService)
        {
            _electricityService = electricityService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateElectricityIncomeModel model)
        {
            return OkResult(_electricityService.Create(model));
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return OkResult(_electricityService.GetList());
        }

        [HttpPatch]
        public IActionResult Update([FromBody] UpdateElectricityIncomeModel model)
        {
            _electricityService.Update(model);

            return OkResult();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteObjectIncomeModel model)
        {
            _electricityService.Delete(model);

            return OkResult();
        }
    }
}
