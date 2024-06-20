using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class JsonModel
    {
        public JsonModel()
        {

        }
        public JsonModel(object responseData, string message, int statusCode, string appError = "")
        {
            data = responseData;
            Message = message;
            StatusCode = statusCode;
            AppError = appError;
        }

        public string AppError { get; set; }
        public object data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public string access_token { get; set; }

    }
    public class Meta
    {
        public Meta()
        {

        }
        public Meta(dynamic T, dynamic searchFilterModel)
        {
            try
            {
                TotalCount = T != null && T.Count > 0 ? T[0].TotalCount : 0;
                CurrentPage = searchFilterModel.pageNumber;
                pageSize = searchFilterModel.pageSize;
                DefaultPageSize = searchFilterModel.pageSize;
                TotalPages = Math.Ceiling(Convert.ToDecimal((T != null && T.Count > 0 ? T[0].TotalCount : 0) / searchFilterModel.pageSize));
            }
            catch (Exception)
            {
            }
        }
        public decimal TotalPages { get; set; }
        public int pageSize { get; set; }
        public int CurrentPage { get; set; }
        public int DefaultPageSize { get; set; }
        public decimal TotalCount { get; set; }
    }
}
