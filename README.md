##  Suny.Infrastructure
## 基于.NET Standard2.0 工具类项目
    ### 结构
	Suny.Infrastructure
	 ### > Extentions
	     ### SystemExtention 扩展日期类型，时间转时间戳，时间戳转时间
	 ### > Json
	     ### UnixTimeMillisecondsConverter dateTime类型json序列化转换器，转换为时间戳格式
	 ### > Utils
	     ### MD5Utils md5辅助工具
	
 
## CNSuny.Core.Mongo
   ## 基于.Core 2.1 mongodb扩展项目
      ## IEntity 实体基接口，所有collection实体类需要实现该接口。
	  ## MongoContext mongodb数据库上下文基类
	  ## MongoContextExtensions mongodb服务扩展类，注册单例mongo数据库上下文
	  ## MongoOptions mongodb数据库配置
	  ## ObjectIdConverter ObjectId序列化自定义转换器，转换为字符串类型id
#### 如何使用？
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
#### CNSuny.Infrastructure.Mvc
   ### BaseApiController 重写了action执行前和执行后的操作，对相应体使用ReponseEntity结构包裹。
   ### CNSunyException 框架自定义异常类型
   ### PageDTO 分页实体
   ### ResponseEntity 响应体包装类
   
   响应结果伪代码：
   {
    "code": 200,
    "msg": "OK",
    "data": [
        "value1",
        "value2"
    ]
   }
