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
                switch (new Random().Next(1, 4))
                {
                    case 1:
                        Actions.Info();
                        break;
                    case 2:
                        Actions.Warning();
                        Logger logger = new Logger();
                        logger.WarningException();

                        break;
                    case 3:
                        Actions.Error();
                        Logger logger1 = new Logger();
                        logger1.ErrorException();
                        break;
                }
            }
        }
    }
}