using System;
using System.Threading.Tasks;

namespace WhenAllMethod
{
    class Program
    {
        static void Adding(int a, int b)
        {
            Console.WriteLine($"Result of adding: {a + b}");
        }

        static void Substraction(int a, int b)
        {
            Console.WriteLine($"Result of substraction: {a - b}");
        }

        static void Multiplication(int a, int b)
        {
            Console.WriteLine($"Result of multiplication: {a * b}");
        }

        static void Division(int a, int b)
        {
            Console.WriteLine($"Result of divison: {a / b}");
        }

        static async void SomeOperationsAsync()
        {
            Task adding = Task.Run(() => Adding(2, 2));
            Task substraction = Task.Run(() => Substraction(a: 5, 1));
            Task multiplication = Task.Run(() => Multiplication(4, 1));
            Task division = Task.Run(() => Division(20, 5));
            await Task.WhenAll(new[] { adding, substraction, multiplication, division });
        }
        static void Main(string[] args)
        {
            SomeOperationsAsync();
            Console.Read();
        }
    }
}
