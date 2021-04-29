using System;
namespace XmasPresent
{
    public class ChocoCandy : Candy
    {
        public string chocoType;
        public ChocoCandy(int weight, string chocoType) : base(weight)
        {
            this.chocoType = chocoType;
        }
    }
}
