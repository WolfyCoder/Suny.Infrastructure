using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CNSuny.Infrastructure.Uitls
{
    /// <summary>
    /// AES 加解密
    /// </summary>
    public static class AesUtil
    {

        #region token加密解密，与node.js和anrdoid配套
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="encryptStr">要加密的字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Encrypt(string encryptStr, string key)
        {
            byte[] keyArray = Getkey(key);
            RijndaelManaged rDel = new RijndaelManaged
            {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = rDel.CreateEncryptor();
            byte[] inputData = Encoding.UTF8.GetBytes(encryptStr);
            byte[] encryptedData = cTransform.TransformFinalBlock(inputData, 0, inputData.Length);

            return ByteToHex(encryptedData);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="decryptStr">要解密的字符串</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        public static string Decrypt(string decryptStr, string key)
        {
            try
            {
                byte[] keyArray = Getkey(key);
                byte[] toEncryptArray = HexToByte(decryptStr);
                RijndaelManaged rDel = new RijndaelManaged
                {
                    Key = keyArray,                  
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform cTransform = rDel.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                string tmp = UTF8Encoding.UTF8.GetString(resultArray);

                int end_index = tmp.LastIndexOf('}');
                if (end_index > 0 && end_index < tmp.Length - 1) tmp = tmp.Remove(end_index + 1);
                return tmp;
            }
            catch
            {
                throw new AesUtilException("Not a standard token,Can not decrypt it.");
            }
        }
        /// <summary>
        /// 密钥
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static byte[] Getkey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException($"密钥{nameof(key)}不能为空，空字符串，空格");
            }
            byte[] result = Encoding.UTF8.GetBytes(key);
            MD5 md5 = new MD5CryptoServiceProvider();
            return md5.ComputeHash(result);
        }

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static string ByteToHex(byte[] bytes)
        {
            StringBuilder result = new StringBuilder();
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    result.Append(bytes[i].ToString("X2"));
                }
            }
            return result.ToString().ToLower();
        }

        private static byte[] HexToByte(string msg)
        {
            //msg = msg.Replace(" ", "");//移除空格
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            }
            return comBuffer;
        }
        #endregion
    }

}
