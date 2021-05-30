using System;
using System.Collections;
using System.Collections.Generic;

namespace Yielder
{
    public class Symbols: IEnumerable<string>
    {
        private readonly string[] bb = {"S", "W", "Q", "D"};
 
        public IEnumerator<string> GetEnumerator()
        {
            foreach (var b in bb)
            {
                yield return b;
            }
        }
 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var symbols = new Symbols();
            foreach (var symbol in symbols)
            {
                Console.WriteLine(symbol);
            }
        }
    }
}