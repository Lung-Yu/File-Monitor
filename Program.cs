using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace File_Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //MailService mailService = MailService.getInstance();
            //mailService.sendNoticeMail(targets.ToArray(), mailContent);
            string path = "check_files/asdasda.txt";

            Console.WriteLine("SHA - " + ToSHA(path));
            Console.WriteLine("MD5 - " + ToMD5(path));


            Console.ReadLine();
        }

        static string ToSHA(string str)
        {
            using (SHA256Managed cryptoSHA = new SHA256Managed())
            {
                //將字串編碼成 UTF8 位元組陣列
                var bytes = Encoding.UTF8.GetBytes(str);

                //取得雜湊值位元組陣列
                var hash = cryptoSHA.ComputeHash(bytes);

                //取得 MD5
                var sha = BitConverter.ToString(hash)
                  .Replace("-", String.Empty)
                  .ToUpper();

                return sha;
            }
        }

        static string ToMD5(string str)
        {
            using (var cryptoMD5 = System.Security.Cryptography.MD5.Create())
            {
                //將字串編碼成 UTF8 位元組陣列
                var bytes = Encoding.UTF8.GetBytes(str);

                //取得雜湊值位元組陣列
                var hash = cryptoMD5.ComputeHash(bytes);

                //取得 MD5
                var md5 = BitConverter.ToString(hash)
                  .Replace("-", String.Empty)
                  .ToUpper();

                return md5;
            }
        }
    }
}
