using System;
using System.IO;
using System.Text;
namespace MyLogger
{
    public class Starter
    {
        public static void Run()
        {

            for (int i = 0; i < 100; i++)
            {
                new Random().Next(1, 3);
                if (new Random().Next(1, 3) == 1)
                {
                    Result.FirstMethod();
                    string typeOfLog = "Info" + Environment.NewLine;
                    File.AppendAllText("log.txt", typeOfLog);
                }
                else if (new Random().Next(1, 3) == 2)
                {
                    Result.SecondMethod();
                    string typeOfLog = "Warning" + Environment.NewLine;
                    File.AppendAllText("log.txt", typeOfLog);
                }
                else
                {
                    Result.ThirdMethod();
                    string typeOfLog = "Error" + Environment.NewLine;
                    File.AppendAllText("log.txt", typeOfLog);
                }
            }
        }
    }
}
