using System;
using System.IO;
using System.Text;
namespace MyLogger
{
    public static class Actions
    {

       public static void Info()
        {
            Result res = new Result(true);
        }

        public static void Warning()
        {
            BusinessException businessException = new BusinessException();
            businessException.BException();
        }

        public static void Error()
        {
            //throw new Exception("Action failed by a reason: Error ");
        }
    }
}
