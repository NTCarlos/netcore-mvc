using System;
using System.Net;

namespace Services.Exceptions.BadRequest
{
    public class BaseNotFoundException : CustomException
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
