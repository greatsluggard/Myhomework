using StackForHomework;
using System;

namespace Task2
{
    class Task2
    {
        static void Main()
        {
            MyStack<char>stack = new MyStack<char>();

            string lineBrackets = Console.ReadLine();
            int countRound = 0;
            int countSquare = 0;
            int countFigure = 0;

            for (int i = 0; i < lineBrackets.Length; i++)
            {
                switch (lineBrackets[i])
                {
                    case '(':
                        countRound++;
                        stack.Push('(');
                        break;
                    case ')':
                        if ((char) stack.Top () == '(' || (char)stack.Top() == '}' || (char)stack.Top() == ']')
                        {
                            stack.Push(')');
                            countRound--;
                        }
                        else
                        {
                            throw new Exception("Ошибка: проверьте баланс скобок!");
                        }
                        break;

                    case '[':
                        countSquare++;
                        stack.Push('[');
                        break;
                    case ']':
                        if ((char)stack.Top() == '[' || (char)stack.Top() == ')' || (char)stack.Top() == '}')
                        {
                            stack.Push(']');
                            countSquare--;
                        }
                        else
                        {
                            throw new Exception("Ошибка: проверьте баланс скобок!");
                        }
                        break;

                    case '{':
                        countFigure++;
                        stack.Push('{');
                        break;
                    case '}':
                        if ((char)stack.Top() == '{' || (char)stack.Top() == ')' || (char)stack.Top() == ']')
                        {
                            stack.Push('}');
                            countFigure--;
                        }
                        else
                        {
                            throw new Exception("Ошибка: проверьте баланс скобок!");
                        }
                    break;
                }
            }

            if ((char)stack.Top() == '(' || (char)stack.Top() == '{' || (char)stack.Top() == '[')
            {
                throw new Exception("Ошибка: стэк не может оканчиваться открывающейся скобкой.");
            }
            
            Console.WriteLine(countRound == 0 && countFigure == 0 && countSquare == 0 ? "строка сбалансирована, всё ок" : "нет баланса скобок!");
        }
    }
}
