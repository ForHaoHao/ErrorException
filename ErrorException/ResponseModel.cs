using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorException
{
    public class ResponseModel
    {
        public int HttpCode {  get; set; }
        public required string Message { get; set; }
        public required string DetailMessage { get; set; }
    }
}
