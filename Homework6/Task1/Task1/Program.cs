using System;
using StackForHomework;

namespace Task1
{
    class Task1
    {
        static void Main()
        {
            MyStack<int> stackForIntermediateResult = new MyStack<int>();
            MyStack<int> stackForGeneralResult = new MyStack<int>(); 

            string expression = Console.ReadLine();

            int symbolToNumber;
            int countForNumbers = 0;

            int topValue = 0;
            int lowValue = 0;

            int intermediateResult = 0;
            int generalResult = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]))
                {
                    symbolToNumber = int.Parse(expression[i].ToString());
                    stackForIntermediateResult.Push(symbolToNumber);
                    countForNumbers++;
                }
            } //если выражение состоит из двух чисел, то последним символом должен быть пробел
            if (countForNumbers == 2)
            {
                expression = expression + " ";
            }                   //если выражение состоит из более чем, двух чисел, последним символом должен быть знак какой-либо операции

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ' ')
                {
                    continue;
                }

                if (char.IsDigit(expression[i]))
                {
                    symbolToNumber = int.Parse(expression[i].ToString());
                    stackForIntermediateResult.Push(symbolToNumber);
                }


                if (i != expression.Length - 1)
                {
                    switch (expression[i])
                    {
                        case '+':
                            topValue = stackForIntermediateResult.Top();
                            stackForIntermediateResult.Pop();

                            lowValue = stackForIntermediateResult.Top();
                            stackForIntermediateResult.Pop();

                            intermediateResult = lowValue + topValue;
                            stackForGeneralResult.Push(intermediateResult);
                            break;

                        case '-':
                            topValue = stackForIntermediateResult.Top();
                            stackForIntermediateResult.Pop();

                            lowValue = stackForIntermediateResult.Top();
                            stackForIntermediateResult.Pop();

                            intermediateResult = lowValue - topValue;
                            stackForGeneralResult.Push(intermediateResult);
                            break;

                        case '*':
                            topValue = stackForIntermediateResult.Top();
                            stackForIntermediateResult.Pop();

                            lowValue = stackForIntermediateResult.Top();
                            stackForIntermediateResult.Pop();

                            intermediateResult = lowValue * topValue;
                            stackForGeneralResult.Push(intermediateResult);
                            break;

                        case '/':
                            topValue = stackForIntermediateResult.Top();
                            stackForIntermediateResult.Pop();

                            lowValue = stackForIntermediateResult.Top();
                            stackForIntermediateResult.Pop();

                            intermediateResult = lowValue / topValue;
                            stackForGeneralResult.Push(intermediateResult);
                            break;
                    }
                }

                if (i == expression.Length - 1)
                {
                    switch (expression[i])
                    {
                        case '+':
                            generalResult = stackForGeneralResult.Top();
                            stackForGeneralResult.Pop();

                            while (stackForGeneralResult.Top() != 0)
                            {
                                generalResult += stackForGeneralResult.Top();
                                stackForGeneralResult.Pop();
                            }

                            break;
                        case '-':
                            generalResult = stackForGeneralResult.Top();
                            stackForGeneralResult.Pop();

                            while (stackForGeneralResult.Top() != 0)
                            {
                                generalResult -= stackForGeneralResult.Top();
                                stackForGeneralResult.Pop();
                            }

                            break;
                        case '*':
                            generalResult = stackForGeneralResult.Top();
                            stackForGeneralResult.Pop();

                            while (stackForGeneralResult.Top() != 0)
                            {
                                generalResult *= stackForGeneralResult.Top();
                                stackForGeneralResult.Pop();
                            }

                            break;
                        case '/':
                            generalResult = stackForGeneralResult.Top();
                            stackForGeneralResult.Pop();

                            while (stackForGeneralResult.Top() != 0)
                            {
                                generalResult /= stackForGeneralResult.Top();
                                stackForGeneralResult.Pop();
                            }

                        break;
                    }
                }
            }

            MyStack<int> value = new MyStack<int>();
            if (value.LenghtStack == 1) 
            {
                Console.WriteLine("Result = " +stackForGeneralResult.Top());
            }
            else
            {
                Console.WriteLine("Result = " +generalResult);
            }
        }
    }
}
