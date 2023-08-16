using StackForHomework;
using System;
using System.Collections.Generic;

namespace Task3
{
    class Task3
    {
        static void Main()
        {
            MyStack<char> stack = new MyStack<char>();

            string mathExpression = Console.ReadLine();
            int count = mathExpression.Length-1;
            int stackSize = 0;
            List<char> numberFromBackets = new List<char>();
           
            for (int i = 0; i < mathExpression.Length; i++)
            {
                if (char.IsNumber(mathExpression[i]))
                {
                    stackSize++;
                }
                if (mathExpression[i] == '+' || mathExpression[i] == '-' || mathExpression[i] == '*' || mathExpression[i] == '/')
                {
                    stackSize++;
                }
            }

            while (stack.LenghtStack != stackSize)
            {
                if (mathExpression[count] == '+' || mathExpression[count] == '-' || mathExpression[count] == '*' || mathExpression[count] == '/')
                {
                    stack.Push(mathExpression[count]);
                }

                if (char.IsNumber(mathExpression[count]))
                {
                    numberFromBackets.Add(mathExpression[count]);
                }

                if ((stack.Top() is char top) && (top == '+' || top == '-' || top == '*' || top == '/'))
                {
                    for (int k = numberFromBackets.Count - 1; k >= 0; k--)
                    {
                        stack.Push(numberFromBackets[k]);
                    }
                    numberFromBackets.Clear();
                }

                if (mathExpression[count] == ')')
                {
                    while (mathExpression[count] != '(')
                    {
                        if (char.IsNumber(mathExpression[count]))
                        {
                            numberFromBackets.Add(mathExpression[count]);
                        }
                        if (mathExpression[count] == '+' || mathExpression[count] == '-' || mathExpression[count] == '*' || mathExpression[count] == '/')
                        {
                            stack.Push(mathExpression[count]);
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
