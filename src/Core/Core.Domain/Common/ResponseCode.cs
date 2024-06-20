using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public static class ResponseCode
    {
        public static int ServerError = 500;
        public static int BadGateway = 502;
        public static int Ok = 200;
        public static int BadRequest = 400;
        public static int Unauthorized = 401;
        public static int NotFound = 404;
        public static int AlreadyExist = 409;
    }
    public static class Status
    {
        public static int Pending = 1;
        public static int Active = 2;
        public static int Declined = 3;
        public static int Upcoming = 4;
        public static int Past = 5;
        public static int Cancelled = 6;

    }
}