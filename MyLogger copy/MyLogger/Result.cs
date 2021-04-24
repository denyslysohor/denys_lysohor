using System;
using System.IO;
using System.Text;
namespace MyLogger
{
    public class Result
    {
        static bool status;
        public static void FirstMethod()
        {
            status = true;
            Console.WriteLine($"{DateTime.Now.ToString()}, Info, Start method: First ");
        }

        public static void SecondMethod()
        {
            status = true;
            Console.WriteLine($"{DateTime.Now.ToString()} Warning, Skipped logic in method: Second ");
        }

        public static void ThirdMethod()
        {
            status = false;
            Console.WriteLine($"{DateTime.Now.ToString()}, Error, Action failed by a reason: I broke a logic");
        }
    }
}
