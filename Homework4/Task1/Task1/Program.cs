using System;

namespace Task1
{
    class Task1
    {
        static void Main()
        {
            sbyte.TryParse(Console.ReadLine(), out sbyte numberOne);
            sbyte.TryParse(Console.ReadLine(), out sbyte numberTwo);
            Console.Clear();
            CodeOfAdditionalForm numberToConvert = new CodeOfAdditionalForm();

            Console.Write($"  {numberOne} => ");
            string res1 = numberToConvert.SuperConverting(numberOne);
            if (numberOne > 0)
            {
                Console.WriteLine(res1.PadLeft(16));
            }
            else
            {
                Console.WriteLine(res1);
            }
            Console.WriteLine("+");

            Console.Write($"  {numberTwo} => ");
            string res2 = numberToConvert.SuperConverting(numberTwo);
            if (numberTwo > 0)
            {
                Console.WriteLine(res2.PadLeft(16));
            }
            else
            {
                Console.WriteLine(res2);
            }

            CodeOfAdditionalForm sum = new CodeOfAdditionalForm();
            string binaryResult = sum.BinarySum(res1, res2);
            sbyte decimalResult = (sbyte)Convert.ToInt32(binaryResult, 2);
            Console.WriteLine("-------------------------");
            Console.WriteLine("       " + binaryResult);
            Console.WriteLine("  " + decimalResult);
        }
    }
}