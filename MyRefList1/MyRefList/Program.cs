using System;

namespace MyRefList
{
    class Program
    {
        static void Main(string[] args)
        {
            RefList refList = new();
            refList.Add(64);
            refList.Add(1);
            refList.Add(5);
            refList.Add(7);
            refList.Add(12);
            refList.Add(8);
            refList.DeleteByValue(8);
            refList.IndexOf(1);
            refList.AddToEnd(18);
        }
    }
}
