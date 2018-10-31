using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Infrastructure
{
    /// <summary>
    /// 分页包装实体类
    /// </summary>
    public class PageDTO<T> where T : class, new()
    {
        private int _page = 1;
        /// <summary>
        /// 当前页数(当前页数，小于等于0时page=1，如果设置了pageCount则最大值不超过pageCount)
        /// </summary>
        public int Page
        {
            get { return _page; }
            set
            {
                if (value <= 0)
                {
                    _page = 1;
                }
                else if (PageCount != 0 && value > PageCount)
                {
                    _page = PageCount;
                }
                else
                {
                    _page = value;
                }

            }
        }
        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { set; get; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { set; get; }
        /// <summary>
        /// 每页数据
        /// </summary>
        public IEnumerable<T> List { set; get; }
    }
}
