using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1
{
    public enum DesType
    {
        Encrypt = 0,    // 암호화
        Decrypt = 1     // 복호화
    }

    public class SecurityUtility
    {
        public SecurityUtility() { }
        public SecurityUtility(string key)
        {
            Key = ASCIIEncoding.ASCII.GetBytes(key);
        }

        private byte[] Key { get; set; }

        public string DesResult(DesType type, string input)
        {
            var des = new DESCryptoServiceProvider()
            {
                Key = Key,
                IV = Key
            };
            var ms = new MemoryStream();

            var property = new
            {
                transform = type.Equals(DesType.Encrypt) ? des.CreateEncryptor() : des.CreateDecryptor(),
                data = type.Equals(DesType.Encrypt) ? Encoding.UTF8.GetBytes(input.ToCharArray()) : Convert.FromBase64String(input)
            };

            var cryStream = new CryptoStream(ms, property.transform, CryptoStreamMode.Write);
            var data = property.data;

            cryStream.Write(data, 0, data.Length);
            cryStream.FlushFinalBlock();

            return type.Equals(DesType.Encrypt) ? Convert.ToBase64String(ms.ToArray()) : Encoding.UTF8.GetString(ms.GetBuffer());
        }//DesResult() end


        public string SHA256Result(string input)
        {
            SHA256 sha = new SHA256Managed();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

    }
}