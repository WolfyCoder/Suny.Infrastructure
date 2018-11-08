namespace CNSuny.Infrastructure.Mvc
{
    /// <summary>
    /// Api Reponse Entity 
    /// </summary>
    public class ResponseEntity
    {
        /// <summary>
        /// 业务处理状态码
        /// </summary>
        public int? Code { set; get; }
        /// <summary>
        /// 业务处理状态描述
        /// </summary>
        public string Msg { set; get; }
        /// <summary>
        /// 业务返回数据
        /// </summary>
        public object Data { set; get; }

    }
}
