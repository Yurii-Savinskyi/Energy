using Microsoft.AspNetCore.Mvc;
using Energy.Common.Models.ApiCommunication;

namespace Energy.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected OkObjectResult OkResult()
        {
            return Ok(new ApiResponse());
        }

        protected OkObjectResult OkResult(object data)
        {
            return Ok(new ApiResponse(data));
        }
    }
}
