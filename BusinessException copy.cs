using System;
using System.Runtime.Serialization;

namespace MyLogger
{
    [Serializable]
    internal class BusinessException : Exception
    {
        public void BException()
        {
            throw new Exception("Skipped logic in Method: Warning");
        }
    }
}
