using Core.Domain.Common;

namespace Api.DTO
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Status = 0;
            Message = ResponseMessage.Error;
            StatusCode = ResponseCode.BadRequest;
        }
        public string Message { get; set; }
        public object ResponseData { get; set; }
        public int Status { get; set; }
        public int StatusCode { get; set; }
        public object? Data { get; set; }
    }
    public class ListResponse<T> : ApiResponse
    {
        public List<T> DataList { get; set; }


    }
}
