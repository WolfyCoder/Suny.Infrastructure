using CNSuny.Infrastructure.Uitls;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试md5
            //string strMd5 = MD5Util.Md5FromString("1234");
            //Console.WriteLine("string md5:" + strMd5);
            //string fileMd5 = MD5Util.Md5FromFile("user.gif");
            //Console.WriteLine(fileMd5);
            //Console.WriteLine(fileMd5 == "0796582A8B780958C53B88AE247D9B37".ToLower());
            //测试时间戳
            //var now = DateTime.Now;
            //Console.WriteLine(now);
            //var ts = now.ToUnixTimeMilliseconds();
            //Console.WriteLine(ts);
            //Console.WriteLine(ts.ToLocalDateTimeTime());
            //测试json
            //string json = new Test { Name = "test" }.ToJson();
            //var test = json.ToEntity<Test>();
            //Console.WriteLine(test.Name);
            //Console.WriteLine(json);
            //测试aes
            //string encryptStr = AesUtil.Encrypt("wolfy", "1234");
            //Console.WriteLine(encryptStr);
            //Console.WriteLine(AesUtil.Decrypt(encryptStr, "1234"));
            //测试null
            NullUtil.ThrowIfNull<string>(" ","test");
            Console.Read();
        }
        class Test
        {
            public string Name { set; get; }

        }
    }
}
