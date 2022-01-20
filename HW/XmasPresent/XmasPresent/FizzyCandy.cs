using System;
namespace XmasPresent
{
    public class FizzyCandy : Lollipop
    {
        public string tasteOfFizzy;
        public FizzyCandy(int weight, string taste, string tasteOfFizzy) : base(weight, taste)
        {
            this.tasteOfFizzy = tasteOfFizzy;
        }
    }
}
