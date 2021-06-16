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
                //Console.WriteLine("Cancelled");
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

        private static async Task FibonachiAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            try
            {
                int fibo = await Task.Run(() => Fibonachi(95, cancellationToken));
                Console.WriteLine($"Result: {fibo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new();
            Task fiboTask = FibonachiAsync(cts.Token);
            Thread.Sleep(10000);
            cts.Cancel();
            Console.WriteLine("Stopped");
        }
    }
}
