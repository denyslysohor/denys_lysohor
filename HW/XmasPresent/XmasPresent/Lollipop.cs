using System;
namespace XmasPresent
{
    public class Lollipop : Candy
    {
        public string taste;
        public Lollipop(int weight, string taste):base(weight)
        {
            this.taste = taste;
        }
    }
}
