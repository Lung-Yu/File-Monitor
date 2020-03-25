using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Monitor
{
    class Recorder
    {

        private string LogFilePath = null;
        private const int COLUMNS_COUNT = 2;
        private StreamWriter pFile = null;
        public Recorder(string csvfilepath)
        {
            LogFilePath = csvfilepath;
            openFileResource();
        }

        public void record(MFileInfo data)
        {
            pFile.WriteLine(string.Format("{0},{1}", data.FullName, data.UniqueCode));
        }

        public void openFileResource()
        {
            pFile = new StreamWriter(LogFilePath);
        }

        public void closeFileResource()
        {
            pFile.Close();
        }

        public DataTable read()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FullName", typeof(string));
            dt.Columns.Add("UniqueCode", typeof(string));

            FileStream fs = new FileStream(LogFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            //記錄每次讀取的一行記錄
            string strLine = "";


            while ((strLine = sr.ReadLine()) != null)
            {
                string[] itme = strLine.Split(',');

                if (COLUMNS_COUNT != itme.Length)
                    continue;

                DataRow row = dt.NewRow();
                row["UniqueCode"] = itme[0];
                row["FullName"] = itme[1];

                dt.Rows.Add(row);
            }

            return dt;
        }

    }
}
