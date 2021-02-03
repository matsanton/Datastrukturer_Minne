using System;

namespace Rekursion_Iteration
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Test RecursiveOdd(n)");
            for (int n = 0; n < 10; n++)
            {
                Console.WriteLine($"{n} : {RecursiveOdd(n)}");
            }

            Console.WriteLine("Test RecursivEven(n)");
            for (int n = 0; n < 10; n++)
            {
                Console.WriteLine($"{n} : {RecursiveEven(n)}");
            }

            //// Test Fibonacci
            //for (int n = 1; n <= 20; n++)
            //{
            //    Console.WriteLine($"fib({n})={Fibonacci(n)}");
            //}
        }

        private static int RecursiveEven(int n)
        {
            if (n == 0) return 2;
            return  RecursiveEven(n - 1) + 2;
        }

        private static int RecursiveOdd(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return (RecursiveOdd(n - 1) + 2);
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
