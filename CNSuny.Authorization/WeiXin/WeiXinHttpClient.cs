using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CNSuny.Authorization.WeiXin
{
    /// <summary>
    /// 微信api客户端
    /// </summary>
    public class WeiXinHttpClient
    {
        private readonly HttpClient _httpClient;
        public WeiXinHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException("参数错误：" + nameof(url));
            }
            return await _httpClient.GetStringAsync(url);
        }
    }
}
