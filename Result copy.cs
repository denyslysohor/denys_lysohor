using System;
using System.IO;
using System.Text;
namespace MyLogger
{
    public class Result
    {
        public bool status;

        public Result(bool value)
        {
            Value = value;
        }

        public bool Value { get; }
    }
}
