using System;
using System.IO;
using System.Reflection;
using System.Text;
namespace MyLogger
{
    public class Logger
    {
        FileService fileService = new FileService();
        public static void DeletingSpareFiles()
        {
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

        public sealed class Singleton
        {
            private static readonly Singleton _logger = new Singleton();

            private Singleton()
            {
            }

            public static Singleton Logger
            {
                get
                {
                    if (_logger is null)
                    {
                        return _logger ?? new Singleton();
                    }
                    return _logger;
                }
            }
        }

        public void WarningException()
        {
            Console.WriteLine($"{DateTime.UtcNow} Warning");
            fileService.WriteBusinnessException("Action got this custom Exception: Skipped logic");

        }

        public void ErrorException()
        {
            Console.WriteLine($"{DateTime.UtcNow} Error");
            fileService.WriteErrorException("Error");
        }
    }
}
