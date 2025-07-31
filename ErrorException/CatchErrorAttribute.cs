using ErrorException;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchError
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Module)]
    public class CatchErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception != null)
            {
                if (context.Exception is not AppException)
                {

                    var errorResponse = new AppException(500, "內部伺服器發生錯誤", context.Exception.Message);
                }
            }
        }
    }
}
