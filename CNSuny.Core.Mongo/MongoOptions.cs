using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Core.Mongo
{
    /// <summary>
    /// mongdb配置
    /// </summary>
    public class MongoOptions
    {
        public string ConnectionString { set; get; }
        public string DataBase { set; get; }
    }
}
