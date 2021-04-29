using System;
namespace XmasPresent
{
    public class JelFizCandy : FizzyCandy
    {
        public string tasteOfJelly;
        public JelFizCandy(int weight, string taste, string tasteOfFizzy, string tasteofJelly) :base(weight, taste, tasteOfFizzy)
        {
            this.tasteOfJelly = tasteofJelly;
        }
    }
}
