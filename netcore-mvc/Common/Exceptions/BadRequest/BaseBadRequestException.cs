using System;
using System.Net;

namespace Common.Exceptions.BadRequest
{
    public class BaseBadRequestException : CustomException
    {
        public new static int HttpCode
        {
            get
            {
                return Convert.ToInt32(HttpStatusCode.BadRequest);
            }
        }
    }
}
