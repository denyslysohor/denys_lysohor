using System;

namespace Visitor
{
    public class Visitor
    {
        public void VisitElement1(Element element1)
        {
            Console.WriteLine($"{element1.GetType().Name} visited by {GetType().Name}"); 
        }
         
        public void VisitElement2(Element element2)
        {
            Console.WriteLine($"{element2.GetType().Name} visited by {GetType().Name}");
        }
    }
}