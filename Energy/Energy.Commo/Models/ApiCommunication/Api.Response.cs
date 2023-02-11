using Energy.Common.StaticResources;
using Energy.Common.StaticResources;

namespace Energy.Common.Models.ApiCommunication
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Message = ApiResponseMessages.Success;
        }

        public ApiResponse(object data)
        {
            Message = ApiResponseMessages.Success;
            Data = data;
        }

        public string Message { get; set; }

        public object Errors { get; set; }

        public object Data { get; set; }
    }
}