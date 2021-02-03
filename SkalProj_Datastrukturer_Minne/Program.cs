using System;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    internal class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        private static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
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
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
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
             * Below you can see some inspirational code to begin working.
            */
            Console.WriteLine("-------- EXAMINE LIST --------");
            var theList = new List<string>();

            while (true)
            {
                Console.WriteLine("+objekt - Lägg till objekt i listan");
                Console.WriteLine("-objekt - Ta bort objekt ur listan");
                Console.WriteLine("x       - Gå till huvudmenyn\n");
                string input = Console.ReadLine();
                char nav = input[0];
                if (nav == 'x') break; // exit this loop

                string value = input[1..];

                switch (nav)
                {
                    case '+':
                        // Add value to the list (The user could write +Adam and "Adam" would be added to the list)
                        Console.WriteLine($"Lägger till {value}");
                        theList.Add(value);
                        break;
                    case '-':
                        // Remove value from the list (The user could write -Adam and "Adam" would be removed from the list)
                        Console.WriteLine($"Raderar {value}");
                        theList.Remove(value);
                        break;
                    default:
                        Console.WriteLine("Använd '+' eller '-'. Om du vill avsluta använd 'x'");
                        break;
                }
                Console.WriteLine($"Capacity: {theList.Capacity}, Count: {theList.Count}");
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
                Console.WriteLine("+objekt - Enque");
                Console.WriteLine("-       - Deque");
                Console.WriteLine("x       - Gå till huvudmenyn\n");
                string input = Console.ReadLine();
                char nav = input[0];
                if (nav == 'x') break; // exit this loop

                string value = input[1..];

                switch (nav)
                {
                    case '+':
                        Console.WriteLine($"{value} ställer sig i kön.");
                        theQueue.Enqueue(value);
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                        {
                            var firstInQueue = theQueue.Dequeue();
                            Console.WriteLine($"{firstInQueue} blir expedierad.");
                        }
                        else
                        {
                            Console.WriteLine("Kön är tom!");
                        }
                        break;
                    default:
                        Console.WriteLine("Använd '+' eller '-'. Om du vill avsluta använd 'x'");
                        break;
                }

                int count = 1;
                foreach (var item in theQueue)
                {
                    Console.WriteLine($"Plats {count++} => {item}");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        private static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Console.WriteLine("-------- EXAMINE STACk --------");
            //var theStack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("R - Reverse string");
                Console.WriteLine("X - Exit to main");
                string input = Console.ReadLine();
                char nav = input[0];
                if (nav == 'x' || nav == 'X') break; // exit this loop
                if (nav == 'r' || nav == 'R')
                {
                    Console.Write("Skriv in en sträng: ");
                    input = Console.ReadLine();
                    string reversed = ReverseText(input);
                    Console.WriteLine(reversed);
                }
            }
        }

        private static string ReverseText(string input)
        {
            var arrOfChar = input.ToCharArray();
            var theStack = new Stack<char>();
            foreach (char ch in arrOfChar)
            {
                theStack.Push(ch); // Sträng: "Mats" => arrOfChar [ 'M', 'a', 't', 's' ] push 'M' push 'a' ...
            }

            int size = theStack.Count;
            char[] reversedCharArray = new Char[size];
            for (int i = 0; i < size; i++)
            {
                reversedCharArray[i] = theStack.Pop();
            }

            string reversedStr = new String(reversedCharArray);
            return reversedStr;
        }

        private static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

