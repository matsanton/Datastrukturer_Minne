using System;

namespace Rekursion_Iteration
{
    internal class Program
    {
        private static void Main()
        {
            for (int n = 1; n <= 20; n++)
            {
                Console.WriteLine($"fib({n})={Fibonacci(n)}");
            }
        }

        private static int Fibonacci(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }

        }
    }
}
