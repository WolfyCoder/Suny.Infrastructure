##  Suny.Infrastructure
## 基于.NET Statndard2.0 工具类项目
## 内置MD5工具包，可获取文件、字符串、stream的md5值
## 内置对DateTime扩展，可快速实现时间转时间戳，时间戳转时间功能
## Mongo用法
#### 配置mongo连接字符串
##### appSettings.json

 "MongoOptions": {
    "ConnectionString": "mongodb://root:root@localhost:27017/BlogDB",
    "DataBase": "BlogDB"
  },
  #### 注册mongo服务
  ###### Startup.cs
    services.Configure<MongoOptions>(Configuration.GetSection("MongoOptions"));
    services.AddCNSunyMongoContext<BlogContext>();
 ## 创建数据库上下文类
  
     public class BlogContext : MongoContext
    {
        public BlogContext(IOptions<MongoOptions> mongoOption) : base(mongoOption.Value)
        {
        }
        //dabase collections
        public IMongoCollection<Models.Blog> Blogs => DataBase.GetCollection<Models.Blog>("Blogs");
        public IMongoCollection<Models.User> Users => DataBase.GetCollection<Models.User>("Users");
        public IMongoCollection<Models.Comment> Comments => DataBase.GetCollection<Models.Comment>("Comments");

    }
