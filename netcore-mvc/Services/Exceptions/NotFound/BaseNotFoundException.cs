using System;
using System.Net;

namespace Services.Exceptions.NotFound
{
    public class BaseNotFoundException : CustomException
    {
        public BaseNotFoundException()
        {
            HttpCode = Convert.ToInt32(HttpStatusCode.NotFound);
        }
    }
}
