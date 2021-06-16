using System;
using System.Threading;
using System.Threading.Tasks;

namespace FiboMethod
{
    class Program
    {
        static int Fibonachi(int num, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new Exception($"Operation canceled by {cancellationToken}");
            }
            if (num == 0 || num == 1)
            {
                return num;
            }
            else
            {
                return Fibonachi(num - 1, cancellationToken) + Fibonachi(num - 2, cancellationToken);
            }
        }

        private static async Task FibonachiAsync(CancellationToken cancellationToken, int num1)
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            try
            {
                int fibo = await Task.Run(() => Fibonachi(num1, cancellationToken));
                Console.WriteLine($"Result: {fibo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task Main(string[] args)
        {
            int num1 = 5;
            CancellationTokenSource cts = new();
            Task fiboTask = FibonachiAsync(cts.Token, num1);
            Thread.Sleep(10000);
            cts.Cancel();
            Console.WriteLine("Stopped");
        }
    }
}
