using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Authorization.WeiXin
{
    /// <summary>
    /// 错误json信息
    /// </summary>
    public class ResponseError
    {
        [JsonProperty("errcode")]
        public int ErrCode { set; get; }
        [JsonProperty("errmsg")]
        public string ErrMsg { set; get; }
    }
}
