using System;
using System.Net;

namespace Common.Exceptions.BadRequest
{
    public class BaseBadRequestException : CustomException
    {
        public BaseBadRequestException()
        {
            HttpCode = Convert.ToInt32(HttpStatusCode.BadRequest);
        }
    }
}
