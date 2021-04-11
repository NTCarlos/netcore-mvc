using System;
using System.Net;

namespace Services.Exceptions.BadRequest
{
    public class BaseBadRequestException : CustomException
    {
        public BaseBadRequestException()
        {
            HttpCode = Convert.ToInt32(HttpStatusCode.BadRequest);
        }
    }
}
