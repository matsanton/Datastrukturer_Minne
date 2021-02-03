using System;

namespace Rekursion_Iteration
{
    internal class Program
    {
        private static void Main()
        {
            //const int LoopSize = 5;
            const int fibSize = 10;

            //Console.WriteLine("Test RecursiveOdd(n)");
            //for (int n = 0; n < LoopSize; n++)
            //{
            //    Console.WriteLine($"{n} : {RecursiveOdd(n)}");
            //}

            //Console.WriteLine("Test RecursivEven(n)");
            //for (int n = 0; n < LoopSize; n++)
            //{
            //    Console.WriteLine($"{n} : {RecursiveEven(n)}");
            //}

            Console.WriteLine("Test Fibonacci(n)");
            for (int n = 1; n <= fibSize; n++)
            {
                Console.WriteLine($"fib({n})={Fibonacci(n)}");
            }

            //Console.WriteLine("Test IterativeOdd(n)");
            //for (int n = 0; n < LoopSize; n++)
            //{
            //    Console.WriteLine($"{n} : {IterativeOdd(n)}");
            //}

            //Console.WriteLine("Test IterativeEven(n)");
            //for (int n = 0; n < LoopSize; n++)
            //{
            //    Console.WriteLine($"{n} : {IterativeEven(n)}");
            //}

            Console.WriteLine("Test IterativeFibonacci(n)");
            for (int n = 1; n <= fibSize; n++)
            {
                Console.WriteLine($"fib({n})={IterativeFibonacci(n)}");
            }

        }

        private static int IterativeFibonacci(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int result = 1;
            int previousResult = 1;
            int beforePreviousResult = 0 ;
            for (int i = 1; i < n; i++)
            {
                result = previousResult + beforePreviousResult; 
                beforePreviousResult = previousResult;
                previousResult = result;
            }
            return result;
        }

        private static int IterativeEven(int n)
        {
            if (n == 0)
            {
                return 2;
            }

            int result = 2;

            for (int i = 0; i < n; i++)
            {
                result += 2;
            }
            return result;
        }

        private static int IterativeOdd(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int result = 1;

            for (int i = 0; i < n; i++)
            {
                result += 2;
            }
            return result;
        }

        private static int RecursiveEven(int n)
        {
            if (n == 0)
            {
                return 2;
            }

            return RecursiveEven(n - 1) + 2;
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
