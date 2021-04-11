using System;
using System.Net;

namespace Common.Exceptions.NotFound
{
    public class BaseNotFoundException : CustomException
    {
        public BaseNotFoundException()
        {
            HttpCode = Convert.ToInt32(HttpStatusCode.NotFound);
        }
    }
}
