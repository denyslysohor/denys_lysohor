using System;
using System.IO;
using System.Reflection;
using System.Text;
namespace MyLogger
{
    public class Logger
    {
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
            FileService fileService = new FileService();
            fileService.BusinnessException();

        }

        public void ErrorException()
        {
            Console.WriteLine($"{DateTime.UtcNow} Error");
            FileService fileService = new FileService();
            fileService.ErrorException();
        }
    }
}
