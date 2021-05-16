using System;
using System.IO;
using System.Text;
namespace MyLogger
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Starter.Run();
            string path = @"/Users/denyslysohor/logs";
            int deleteStatement = 3;
            string[] files = Directory.GetFiles(path);
            while (files.Length > deleteStatement)
            {
                DateTime dateMin = DateTime.MaxValue;
                string nameMinFile = string.Empty;
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.CreationTime < dateMin)
                    {
                        dateMin = fi.CreationTime;
                        nameMinFile = fi.FullName;
                    }
                }

                if (nameMinFile != string.Empty)
                {
                    File.Delete(nameMinFile);
                    files = Directory.GetFiles(path);
                }
            }
        }
    }
}
