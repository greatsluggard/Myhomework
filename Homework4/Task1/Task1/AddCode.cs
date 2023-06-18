using System;

namespace Task1
{
    class AddCode
    {
        public string SuperConverter(sbyte value)
        {
            string numberInBinary = Convert.ToString(value, 2);
            for (int i = 0; i < numberInBinary.Length; i++)
            {
                if (numberInBinary[0] != 0)
                {
                    numberInBinary.Replace("0", "1");
                    numberInBinary.Replace("1", "0");
                }
            }
            return numberInBinary;
        }

        public string BinarySum(string first, string second)
        {
            string result = Convert.ToString(Convert.ToInt32(first, 2) + Convert.ToInt32(second, 2), 2);
            return result;
        }
    }
}
