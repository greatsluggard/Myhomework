using StackForHomework;
using System;
using System.Collections.Generic;

namespace Task3
{
    class Task3
    {
        static void Main()
        {
            MyStack stack = new MyStack();

            string math = Console.ReadLine();
            int count = math.Length-1;
            int stackSize = 0;
            List<char> numberFromBackets = new List<char>();
           
            for (int i = 0; i < math.Length; i++)
            {
                if (char.IsNumber(math[i]))
                {
                    stackSize++;
                }
                if (math[i] == '+' || math[i] == '-' || math[i] == '*' || math[i] == '/')
                {
                    stackSize++;
                }
            }

            while (stack.Size() != stackSize)
            {
                if (math[count] == '+' || math[count] == '-' || math[count] == '*' || math[count] == '/')
                {
                    stack.Push(math[count]);
                }

                if (char.IsNumber(math[count]))
                {
                    numberFromBackets.Add(math[count]);
                }

                if ((stack.Top() is char top) && (top == '+' || top == '-' || top == '*' || top == '/'))
                {
                    for (int k = numberFromBackets.Count - 1; k >= 0; k--)
                    {
                        stack.Push(numberFromBackets[k]);
                    }
                    numberFromBackets.Clear();
                }

                if (math[count] == ')')
                {
                    while (math[count] != '(')
                    {
                        if (char.IsNumber(math[count]))
                        {
                            numberFromBackets.Add(math[count]);
                        }
                        if (math[count] == '+' || math[count] == '-' || math[count] == '*' || math[count] == '/')
                        {
                            stack.Push(math[count]);
                        }
                        count--;
                    }
                    for (int j = 0; j < numberFromBackets.Count; j++)
                    {
                        stack.Push(numberFromBackets[j]);
                    }
                    numberFromBackets.Clear();
                }

                count--;
            }

            foreach (object symbol in stack)
            {
                Console.Write(symbol + " ");
            }
        }
    }
}
