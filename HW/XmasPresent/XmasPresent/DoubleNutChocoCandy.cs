using System;
namespace XmasPresent
{
    public class DoubleNutChocoCandy : ChocoNutCandy
    {
        public string secondChoco;
        public DoubleNutChocoCandy(int weight, string chocoType, string nutType, string secondChoco):base(weight, chocoType, nutType)
        {
            this.secondChoco = secondChoco;
        }
    }
}
