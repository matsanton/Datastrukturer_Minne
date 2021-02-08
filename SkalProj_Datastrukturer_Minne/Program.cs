// Svar på frågor:
// Stack och heap
// 1. Stacken fungerar som en hög med tallrikar; First in, Last out-principen. Används för att allokera minnet vid statiska
//    funktions-anrop. Om ett nytt anrop sker innifrån den funktionen skapas ett till block på stacken som mäste avslutas
//    först innan minnet kan återanvändas.
//    Heapen är ett minnesområde som garbage collectorn sköter om. När man skapar ett objekt med nycklordet new tilldelas
//    en bit av heapen.
// 2. Variabler som är Value Types lagrar värdet direkt, antingen på stacken eller på heapen beroende på var de deklarerats.
//    Variabler som är Reference Types innehåller en referens till en plats i minnet (på heapen) där värdet ligger lagrat.
// 3. I metoden ReturnValue är x och y variabler av typen int, alltså Value Types. Dessa variabler håller 
//    värdet direkt. x tilldelas 3 och innehåller däför heltalet 3. Innhhållet i x returneras i sista raden i metoden, 
//    alltså returneras heltalet 3.
//    I ReturnValue2 är MyInt en klass och alltså en referenstyp. x innehåller en referens till en instans av klassen MyInt.
//    En ny instans skapas som tilldelas varibeln y. Sedan sätts y till värdet i x. Både x och y refererar nu till samma
//    instans. MyValue i den instansen sätts till 4 och x.MyValue returneras, alltså heltalet 4.
// --------------------------------------------------------------------------------------------------------------------------
//
//  ExamineList()
//  Den underliggande arrayen har från början 4 platser. 
//  2. När den är full utökas den till 8 och när de platserna fyllts ökas den till 16 och så vidare. 
//  3. Alltså fördubblas kapaciteten varje gång den behöver utökas.
//  4. Det tar lång tid att köra funktionen som allokerar minne för List, därför allokeras flera platser åt gången.
//  5. Nej
//  6. När man vet maximala storleksbehovet på arrayen från början.
// --------------------------------------------------------------------------------------------------------------------------
//
//  ExamineStack()
//  1. Den som kommer först kommer att bli servad sist så länge det kommer in fler folk i affären.
// --------------------------------------------------------------------------------------------------------------------------
//
//  CheckParanthesis()
//  En stack är bra att använda i detta fallet. Pucha upp första parentesen och poppa när en avslutande parentes läses för att
//  kolla om de matchar. 
// --------------------------------------------------------------------------------------------------------------------------
//
//  Rekursion och iteration
//  Iteration är mest minnesvänlig, rekursion skapar ett nytt "scope-block" på stacken vid varje anrop till sig själv. Detta
//  minne kan inte börja återanvändas förrän sista anropets block var avslutats.

using System;
using System.Collections.Generic;

namespace Datastrukturer_Minne
{
    internal class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \nof your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. Test recursive methods"
                    + "\n6. Test iterative methods"
                    + "\n0. Exit the application");
                // Creates the character input to be used with the switch-case below.
                char input = ' ';
                try
                {
                    // Tries to set input to the first char in an input line.
                    input = Console.ReadLine()[0];
                }
                // If the input line is empty, we ask the users for some input.
                catch (IndexOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        TestRecursiveMethods();
                        break;
                    case '6':
                        TestIterativeMethods();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        private static void ExamineList()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
            */
            Console.WriteLine("-------- EXAMINE LIST --------");
            var theList = new List<string>();
            while (true)
            {
                Console.WriteLine("+objekt - Add object to the list");
                Console.WriteLine("-objekt - Remove object from the list");
                Console.WriteLine("X       - Exit to main menu\n");

                string input = Console.ReadLine();
                if (input == "")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                    continue;
                }
                char nav = input[0];
                string value = input[1..];
                switch (nav)
                {
                    case '+':
                        Console.WriteLine($"Adding {value}");
                        theList.Add(value);
                        break;
                    case '-':
                        if (theList.Remove(value))
                            Console.WriteLine($"Removing {value}");
                        else if (value == String.Empty)
                            Console.WriteLine("Enter something to remove.");
                        else
                            Console.WriteLine($"Could not find {value} in the list.");
                        break;
                    case 'x':
                    case 'X':
                        return;
                    default:
                        Console.WriteLine("Use + or - before a string to modify the list. Enter X to exit.");
                        break;
                }

                if (theList.Count != 0)
                {
                    Console.WriteLine($"Capacity: {theList.Capacity}, Count: {theList.Count}");
                    foreach (var item in theList)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        private static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Console.WriteLine("-------- EXAMINE QUEUE --------");
            var theQueue = new Queue<string>();
            while (true)
            {
                Console.WriteLine("+objekt - Enqueu");
                Console.WriteLine("-       - Dequeu");
                Console.WriteLine("X       - Exit to main menu\n");

                string input = Console.ReadLine();
                if (input == "")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                    continue;
                }
                char nav = input[0];
                string value = input[1..];
                switch (nav)
                {
                    case '+':
                        Console.WriteLine($"{value} enters the queue.");
                        theQueue.Enqueue(value);
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                        {
                            var firstInQueue = theQueue.Dequeue();
                            Console.WriteLine($"{firstInQueue} served, exits the store.");
                        }
                        else
                        {
                            Console.WriteLine("The queue is empty!");
                        }
                        break;
                    case 'x':
                    case 'X':
                        return;
                    default:
                        Console.WriteLine("Use + or - to modify the queue. Enter X to exit.");
                        break;
                }

                if (theQueue.Count != 0)
                {
                    int count = 1;
                    foreach (var item in theQueue)
                    {
                        Console.WriteLine($"Position in queue: {count++} => {item}");
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        private static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Console.WriteLine("-------- EXAMINE STACK --------");
            var theStack = new Stack<string>();
            while (true)
            {
                Console.WriteLine("+objekt - Push to stack");
                Console.WriteLine("-       - Pop");
                Console.WriteLine("R       - Reverse string");
                Console.WriteLine("X       - Exit to main\n");

                string input = Console.ReadLine();
                if (input == "")
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                    continue;
                }
                char nav = input[0];
                string value = input[1..];
                switch (nav)
                {
                    case '+':
                        Console.WriteLine($"{value} Pushed to the stack.");
                        theStack.Push(value);
                        break;
                    case '-':
                        string str;
                        if (theStack.Count != 0)
                        {
                            str = theStack.Pop();
                            Console.WriteLine($"Popped {str}");
                        }
                        else
                        {
                            Console.WriteLine("The stack is empty!");
                        }
                        break;
                    case 'r':
                    case 'R':
                        ReverseText();
                        break;
                    case 'x':
                    case 'X':
                        return;
                }

                if (theStack.Count != 0)
                {
                    int pos = 0;
                    foreach (var item in theStack)
                    {

                        Console.WriteLine($"{pos++}: {item}");
                    }
                }
            }
        }

        /// <summary>
        /// Reverses a text string
        /// </summary>
        private static void ReverseText()
        {
            Console.Write("Enter a text string: ");
            string input = Console.ReadLine();

            var theStack = new Stack<char>();
            // Push all characters to the stack 
            foreach (var ch in input)
            {
                theStack.Push(ch);
            }
            int size = theStack.Count;
            var reversed = new Char[size];
            for (int i = 0; i < size; i++)
            {
                reversed[i] = theStack.Pop();
            }
            Console.WriteLine(new String(reversed));
        }

        private static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Console.WriteLine("-------- CHECK PARENTHESIS --------");
            Console.WriteLine("Tests:");
            Console.WriteLine("Valid strings:");
            Console.WriteLine($"Expected: Valid, Actual: {(IsValid("(())") ? "Valid" : "Not valid")}");
            Console.WriteLine($"Expected: Valid, Actual: {(IsValid("{ }") ? "Valid" : "Not valid")}");
            Console.WriteLine($"Expected: Valid, Actual: {(IsValid("[({ })]") ? "Valid" : "Not valid")}");
            Console.WriteLine($"Expected: Valid, Actual: " +
                $"{(IsValid("List<int> list = new List<int>() { 1, 2, 3, 4 };") ? "Valid" : "Not valid")}");
            Console.WriteLine("Not valid strings:");
            Console.WriteLine($"Expected: Not valid, Actual: {(IsValid("]") ? "Valid" : "Not valid")}");
            Console.WriteLine($"Expected: Not valid, Actual: {(IsValid("(()])") ? "Valid" : "Not valid")}");
            Console.WriteLine($"Expected: Not valid, Actual: {(IsValid("[)") ? "Valid" : "Not valid")}");
            Console.WriteLine($"Expected: Not valid, Actual: {(IsValid("{[()}]") ? "Valid" : "Not valid")}");
            Console.WriteLine($"Expected: Not valid, Actual: " +
                $"{(IsValid("List<int> list = new List<int>() { 1, 2, 3, 4 );") ? "Valid" : "Not valid")}");

            Console.Write("Enter text: ");
            string input = Console.ReadLine();
            if (IsValid(input))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\"{input}\" => String valid");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\"{input}\" => String not valid");
            }
            Console.ResetColor();
        }

        private static bool IsValid(string input)
        {
            var stack = new Stack<char>();
            var match = new Dictionary<char, char> { { '(', ')' }, { '{', '}' }, { '[', ']' } };
            foreach (var ch in input)
            {
                switch (ch)
                {
                    case '(':
                    case '{':
                    case '[':
                        // If any type of opening parenthesis: 
                        // Push the matching closing parenthesis to the stack.
                        stack.Push(match[ch]);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        // If any type of closing parenthesis: 
                        // If there is nothing to pop, we don't have an opening parenthesis.
                        if (stack.Count == 0)
                            return false;
                        // If latest character on stack wasn't the same closing parenthesis:
                        // we found an error, return false.
                        if (stack.Pop() != ch)
                            return false;
                        break;
                }
            }
            // If there is anything left on the stack then we don't have matching pairs of parentheses.
            if (stack.Count != 0)
                return false;
            else
                return true;
        }


        #region Recursive methods
        private static void TestRecursiveMethods(int loopSize = 10)
        {
            Console.WriteLine("Test RecursiveOdd(n)");
            for (int n = 0; n < loopSize; n++)
            {
                Console.WriteLine($"{n} : {RecursiveOdd(n)}");
            }

            Console.WriteLine("Test RecursivEven(n)");
            for (int n = 0; n < loopSize; n++)
            {
                Console.WriteLine($"{n} : {RecursiveEven(n)}");
            }

            Console.WriteLine("Test recursive Fibonacci(n)");
            for (int n = 1; n <= loopSize; n++)
            {
                Console.WriteLine($"fib({n})={Fibonacci(n)}");
            }
        }
        public static int RecursiveOdd(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return (RecursiveOdd(n - 1) + 2);
        }
        public static int RecursiveEven(int n)
        {
            if (n == 0)
            {
                return 2;
            }
            return RecursiveEven(n - 1) + 2;
        }
        public static int Fibonacci(int n)
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
        #endregion

        #region Iterative methods
        private static void TestIterativeMethods(int loopSize = 10)
        {
            Console.WriteLine("Test IterativeOdd(n)");
            for (int n = 0; n < loopSize; n++)
            {
                Console.WriteLine($"{n} : {IterativeOdd(n)}");
            }

            Console.WriteLine("Test IterativeEven(n)");
            for (int n = 0; n < loopSize; n++)
            {
                Console.WriteLine($"{n} : {IterativeEven(n)}");
            }

            Console.WriteLine("Test IterativeFibonacci(n)");
            for (int n = 1; n <= loopSize; n++)
            {
                Console.WriteLine($"fib({n})={IterativeFibonacci(n)}");
            }
        }
        public static int IterativeOdd(int n)
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
        public static int IterativeEven(int n)
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
        public static int IterativeFibonacci(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int result = 1;
            int prevResult = 1;
            int beforePreviousResult = 0;
            for (int i = 1; i < n; i++)
            {
                result = prevResult + beforePreviousResult; // calculate current loop
                beforePreviousResult = prevResult; // save to next loop
                prevResult = result; //save to next loop
            }
            return result;
        }
        #endregion

    }
}


