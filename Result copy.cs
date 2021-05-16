using System;
using System.IO;
using System.Text;
namespace MyLogger
{
    public class Result
    {
        public bool status;

        public Result(bool v)
        {
            V = v;
        }

        public bool V { get; }
    }
}
