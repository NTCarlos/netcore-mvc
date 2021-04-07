using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class CustomException : Exception
    {
        public int HttpCode { get; set; }
        public string CustomMessage { get; set; }
    }
}
