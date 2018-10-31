using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CNSuny.Infrastructure.Uitls
{
    /// <summary>
    /// md5 工具类
    /// </summary>
    public class MD5Util
    {
        /// <summary>
        /// 获取字符串md5值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5FromString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException($"{nameof(input)}");
            }
            using (MD5 md5 = MD5.Create())
            {
                StringBuilder sb = new StringBuilder();
                byte[] buffer = Encoding.UTF8.GetBytes(input);
                buffer = md5.ComputeHash(buffer);
                for (int i = 0; i < buffer.Length; i++)
                {
                    sb.Append(buffer[i].ToString("x2"));
                }
                return sb.ToString();
            }

        }
        /// <summary>
        /// 获取文件md5值
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string Md5FromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)}");
            }
            if (!System.IO.File.Exists(filePath))
            {
                throw new ArgumentException($"{filePath} Not Found.");
            }

            using (System.IO.FileStream fs = new System.IO.FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                return Md5FromStream(fs);
            }


        }
        /// <summary>
        /// 获取流md5值
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string Md5FromStream(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException($"{nameof(stream)}");
            }
            StringBuilder sb = new StringBuilder();
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = md5.ComputeHash(stream);
                for (int i = 0; i < buffer.Length; i++)
                {
                    sb.Append(buffer[i].ToString("x2"));
                }
            }
            return sb.ToString();
        }
    }
}
