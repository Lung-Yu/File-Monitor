﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace File_Monitor
{
    class Program
    {
        const int GET_FOLDERS = 1000;
        const int GET_FILES = 100;
        private static ConfigParser config = null;
        private static Recorder recorder = null;
        private static MailService mailService = null;
        private static List<MFileInfo> listFileInfo;

        private const string LOG_RECORD_FILE = "first_log.csv";



        static void Main(string[] args)
        {
            //RecordAllFile();

            CheckAllFile();

            Console.ReadLine();
        }

        static void visitAllFiles()
        {
            listFileInfo = new List<MFileInfo>();
            foreach (string check_folder in config.Checks)
            {
                #region 目錄遍訪
                //string check_folder = "check_files";

                DirectoryInfo info = new DirectoryInfo(check_folder);
                foreach (FileSystemInfo item in info.GetFileSystemInfos())
                {
                    ListFiles(item);
                }
                #endregion
            }
        }

        static void CheckAllFile()
        {
            //get all record from log
            mailService = MailService.getInstance();
            config = mailService.getConfigParser();
            recorder = new Recorder(LOG_RECORD_FILE);
            DataTable dt = recorder.read();
            dt.Columns.Add("Check", typeof(string), "0");

            visitAllFiles();

            foreach (MFileInfo real in listFileInfo)
            {
                string sqlWhere = string.Format("{0} = '{1}'",
                    Recorder.COLUMN_FULL_NAME,
                    real.FullName);
                DataRow[] rows = dt.Select(sqlWhere);

                //discover new file
                if (rows.Length == 0)
                {
                    Console.WriteLine("哪個人偷放怪東西!!! \t >>> \t " + real.FileName);
                }

                for (int i = 0; i < rows.Length; i++)
                {
                    Console.WriteLine(string.Format("{0} {1}",
                        rows[i][Recorder.COLUMN_FULL_NAME],
                        rows[i][Recorder.COLUMN_UNIQUE_CODE]
                        ));
                }
            }

        }

        static void RecordAllFile()
        {
            mailService = MailService.getInstance();
            //mailService.sendNoticeMail(targets.ToArray(), mailContent);
            //string path = "check_files/asdasda.txt";

            //Console.WriteLine("SHA - " + ToSHA(path));
            //Console.WriteLine("MD5 - " + ToMD5(path));

            config = mailService.getConfigParser();
            recorder = new Recorder(LOG_RECORD_FILE);
            recorder.openFileResource();



            recorder.closeFileResource();
        }

        private static bool IsIgnore(string check_full_path)
        {
            List<string> full_lists = new List<string>();
            foreach (string ignore in config.Ignores)
            {
                string ignore_full_name = new DirectoryInfo(ignore).FullName;

                //Console.WriteLine(ignore_full_name);
                //Console.WriteLine(check_full_path);

                if (check_full_path.Equals(ignore_full_name))
                {
                    return true;
                }
            }
            return false;
        }

        public static void ListFiles(FileSystemInfo fileSysInfo)
        {
            MFileInfo info = new MFileInfo();
            info.FullName = fileSysInfo.FullName;
            info.FileName = fileSysInfo.Name;

            if (IsIgnore(info.FullName))
                return;
            else if (System.IO.Directory.Exists(info.FullName))
                info.IsFolder = true;
            else if (System.IO.File.Exists(info.FullName))
                info.IsFolder = false;
            else
                return;


            if (info.IsFolder)
            {
                info.UniqueCode = ToSHA(info.FullName);

                DirectoryInfo dirInfo = new DirectoryInfo(info.FullName);
                foreach (FileSystemInfo item in dirInfo.GetFileSystemInfos())
                    ListFiles(item);
            }
            else
                info.UniqueCode = ToSHA(info.FullName);

            //info.show();
            listFileInfo.Add(info);
        }

        static List<string> getList(string path, int type)
        {
            List<string> list = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(path);

            switch (type)
            {
                case GET_FOLDERS:
                    foreach (var dChild in dir.GetFiles("*"))
                        list.Add(dChild.Name);
                    break;
                case GET_FILES:
                    foreach (var dChild in dir.GetDirectories("*"))
                        list.Add(dChild.Name);
                    break;
                default:
                    break;
            }

            return list;
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

