using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Monitor
{
    class MFileInfo
    {
        public string FileName {get; set;}
        public string FullName {get; set;}
        public string UniqueCode { get; set; }
        public bool IsFolder { get; set; }

        public void show()
        {
            Console.WriteLine("File Name :\t" + FileName);
            Console.WriteLine("FullFileName :\t" + FullName);
            Console.WriteLine("UniqueCode :\t" + UniqueCode);
            Console.WriteLine("IsFolder :\t" + IsFolder);
            Console.WriteLine("******************************");
        }
    }
}
