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
            private static readonly Singleton logger = new Singleton();

            static Singleton()
            {
            }

            private Singleton()
            {
            }

            public static Singleton Logger
            {
                get
                {
                    return logger;
                }
            }
        }
    }
}
