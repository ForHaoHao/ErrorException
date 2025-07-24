using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorException
{
    public class AppException : Exception
    {
        public int HttpCode {  get; set; }
        public string MessageTitle { get; set; }
        public AppException(int httpCode, string messageTitle)
        {
            HttpCode = httpCode;
            this.MessageTitle = messageTitle;
        }
        public AppException(int httpCode, string messageTitle, string message) : base(message)
        {
            this.HttpCode = httpCode;
            this.MessageTitle = messageTitle;
        }
    }
}
