using Suny.Infrastructure.Uitls;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string strMd5 = MD5Util.Md5FromString("1234");
            Console.WriteLine("string md5:" + strMd5);
            string fileMd5 = MD5Util.Md5FromFile("user.gif");
            Console.WriteLine(fileMd5);
            Console.WriteLine(fileMd5 == "0796582A8B780958C53B88AE247D9B37".ToLower());
            var now = DateTime.Now;
            Console.WriteLine(now);
            var ts = now.ToUnixTimeMilliseconds();
            Console.WriteLine(ts);
            Console.WriteLine(ts.ToLocalDateTimeTime());
            Console.Read();
        }
    }
}
