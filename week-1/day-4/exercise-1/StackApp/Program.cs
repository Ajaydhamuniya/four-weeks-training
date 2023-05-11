using System;
using System.Collections.Generic;
namespace StackApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            Stack<string> stack2 = new Stack<String>();
            Console.WriteLine("Enter the  Integer Value of Stack");
            stack.Push(Convert.ToInt32(Console.ReadLine()));
            stack.Push(Convert.ToInt32(Console.ReadLine()));
            stack.Push(Convert.ToInt32(Console.ReadLine()));
            stack.Push(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Enter the String Value:");
            stack2.Push(Console.ReadLine());
            stack2.Push(Console.ReadLine());

            Console.WriteLine("Elements in Stacks after Push in Integer:");
            foreach (var item in stack)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Elements in Stacks after Push in Integer:");
            foreach (var item in stack2)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine($"No of Element in Integer Stack:{stack.Count}");
            Console.WriteLine($"No of Element in String Stack:{stack2.Count}");

            stack.Pop();
            stack2.Pop();
            /* stack2.Pop()*/
            ;
            Console.WriteLine("ELment After Pop:");
            

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack2)
            {
                Console.WriteLine(item);

                if (stack.Count <= 0)
                {
                    Console.WriteLine("Stack is Empty");
                }

                if(stack2.Count<= 0)
                {
                    Console.WriteLine("string stack is empty");



                }

                //ICustomStack<int> intStack = new CustomStack<int>();
                //intStack.Push(1);
                //intStack.Push(2);
                //intStack.Push(3);
                //Console.WriteLine(intStack.Pop()); // Output: 3
                //Console.WriteLine(intStack.Pop()); // Output: 2
            
                //Console.WriteLine(Stack.IsEmpty()) ; // Output: False
            }
        }
    } 
}