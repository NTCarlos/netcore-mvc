using System;

namespace Common.Exceptions
{
    public class CustomException : Exception
    {
        public int HttpCode { get; set; }
        public string CustomMessage { get; set; }
    }
}
