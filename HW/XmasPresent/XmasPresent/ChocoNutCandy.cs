using System;
namespace XmasPresent
{
    public class ChocoNutCandy : ChocoCandy
    {
        public string nutType;
        public ChocoNutCandy(int weight, string chocoType, string nutType):base(weight, chocoType)
        {
            this.nutType = nutType;
        }

    }
}
