using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Authorization.WeiXin
{
    public class WxUser
    {
        /// <summary>
        /// 普通用户的标识，对当前开发者帐号唯一
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { set; get; }
        /// <summary>
        /// 普通用户昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { set; get; }
        /// <summary>
        /// 普通用户性别，1为男性，2为女性
        /// </summary>
        [JsonProperty("sex")]
        public int Sex { set; get; }
        /// <summary>
        /// 普通用户个人资料填写的省份
        /// </summary>
        [JsonProperty("province")]
        public string Province { set; get; }
        /// <summary>
        /// 普通用户个人资料填写的城市
        /// </summary>
        [JsonProperty("city")]
        public string City { set; get; }
        /// <summary>
        /// 国家，如中国为CN
        /// </summary>
        [JsonProperty("country")]
        public string Country { set; get; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
        /// </summary>
        [JsonProperty("headimgurl")]
        public string HeadImgUrl { set; get; }
        /// <summary>
        /// 用户特权信息，json数组，如微信沃卡用户为（chinaunicom）
        /// </summary>
        [JsonProperty("privilege")]
        public string Privilege { set; get; }
        /// <summary>
        /// 用户统一标识。针对一个微信开放平台帐号下的应用，同一用户的unionid是唯一的。
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { set; get; }
    }
}
