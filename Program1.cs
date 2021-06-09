using System;

namespace Visitor
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Element1 el1 = new();
            Element2 el2 = new();
            
            ObjectStructure objStruct = new ObjectStructure();
            
            Console.WriteLine();
            
            objStruct.Attach(el1);
            objStruct.Attach(el2);
            objStruct.Detach(el2);
            
            Visitor v = new Visitor();
            
            objStruct.Accept(v);
        }
    }
}