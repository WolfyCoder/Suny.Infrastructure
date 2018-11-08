using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CNSuny.Infrastructure.Mvc
{
    public class BaseApiController : Controller
    {
        class Error
        {
            public string Key { set; get; }
            public List<string> Msg { set; get; }
        }
    
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!ModelState.IsValid)
            {
                List<Error> lst = new List<Error>();
                foreach (var item in ModelState.Keys)
                {
                    if (!lst.Any(x => x.Key == item))
                    {
                        lst.Add(new Error
                        {
                            Key = item,
                            Msg = ModelState[item].Errors.Select(x => x.ErrorMessage).ToList()
                        });
                    }
                }
                context.Result = new JsonResult(new ResponseEntity
                {
                    Code = StatusCodes.Status400BadRequest,
                    Msg = "模型绑定失败",
                    Data = lst
                });
            }
            base.OnActionExecuting(context);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string msg = "OK";
            int code = StatusCodes.Status200OK;
            if (context.Exception != null)
            {
                string stackMessage = string.Empty;
                if (context.Exception is CNSunyException cNSunyException)
                {
#if DEBUG
                    stackMessage = cNSunyException.StackTrace;
#else
                    stackMessage= cNSunyException.Message;
#endif
                    msg = cNSunyException.Message;
                    code = cNSunyException.StatusCode;
                }
                else
                {
#if DEBUG
                    stackMessage = context.Exception.StackTrace;
#else
                    stackMessage= context.Exception.Message;
#endif
                    msg = context.Exception.Message;
                    code = StatusCodes.Status500InternalServerError;
                }

                context.Result = new JsonResult(new ResponseEntity
                {
                    Data = stackMessage,
                    Msg = msg,
                    Code = code
                });
                //设置异常已被处理的标志，其它地方不再接收到该异常信息
                context.ExceptionHandled = true;
            }
            else
            {
                if (context.Result is ObjectResult result)
                {
                    context.Result = new JsonResult(new ResponseEntity
                    {
                        Data = result.Value,
                        Msg = msg,
                        Code = code
                    });
                }
            }
            base.OnActionExecuted(context);

        }
    }
}
