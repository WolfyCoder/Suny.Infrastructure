using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Authorization.WeiXin
{
    /// <summary>
    /// 微信配置
    /// </summary>
    public class WeiXinOptions
    {
        /// <summary>
        /// 应用唯一标识，在微信开放平台提交应用审核通过后获得
        /// </summary>
        public string AppId { set; get; }
        /// <summary>
        /// 应用密钥AppSecret，在微信开放平台提交应用审核通过后获得
        /// </summary>
        public string Secret { set; get; }
        /// <summary>
        /// 获取access_token的api
        /// </summary>
        public string AccessTokenApi => $"https://api.weixin.qq.com/sns/oauth2/access_token?appid={AppId}&secret={Secret}&code=CODE&grant_type=authorization_code";
        /*
         access_token是调用授权关系接口的调用凭证，由于access_token有效期（目前为2个小时）较短，当access_token超时后，可以使用refresh_token进行刷新，access_token刷新结果有两种：

          1. 若access_token已超时，那么进行refresh_token会获取一个新的access_token，新的超时时间；

          2. 若access_token未超时，那么进行refresh_token不会改变access_token，但超时时间会刷新，相当于续期access_token。

          refresh_token拥有较长的有效期（30天），当refresh_token失效的后，需要用户重新授权，所以，请开发者在refresh_token即将过期时（如第29天时），进行定时的自动刷新并保存好它。
               */
        public string RefreshTokenApi => $"https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={AppId}&grant_type=refresh_token&refresh_token={0}";

    }
}
