using System;

namespace XmasPresent
{
    public class Libra
    {
        public static void MaxWeigth(Candy[] candies)
        {
            int max = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i].weight > max)
                {
                    max = candies[i].weight;
                }
            }
            Console.WriteLine($"The biggest weight: {max}");
        }
        class MainClass
        {
            public static void Main(string[] args)
            {
                Candy[] candies = new Candy[16]{ new Lollipop(25, "bitter"),
        new Lollipop(21, "sweet"),
        new Lollipop(4, "sour"),
        new FizzyCandy(22, "sour", "bitter"),
        new FizzyCandy(24, "sour", "sour"),
        new FizzyCandy(32, "sweet", "sour"),
        new JelFizCandy(44, "bitter", "sour", "sweet"),
        new JelFizCandy(43, "bitter", "sour", "sour"),
        new ChocoCandy(22, "white"),
        new ChocoCandy(26, "black"),
        new ChocoNutCandy(23, "white", "almond"),
        new ChocoNutCandy(16, "black", "peanuts"),
        new ChocoNutCandy(23, "black", "pistachio"),
        new DoubleNutChocoCandy(54, "white", "peanuts", "black"),
        new DoubleNutChocoCandy(80, "white", "peanuts", "white"),
        new DoubleNutChocoCandy(10, "white", "almond", "black")
        };
                MaxWeigth(candies);
            }
        }

    }
}
