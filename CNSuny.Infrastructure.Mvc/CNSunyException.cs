using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Infrastructure.Mvc
{
    /// <summary>
    /// 框架自定义异常
    /// </summary>
    public class CNSunyException : Exception
    {
        public CNSunyException(string message, int statusCodes)
        {
            StatusCode = statusCodes;
            Message = message;
        }
        public int StatusCode { set; get; }
        public override string Message { get; }
    }
}
