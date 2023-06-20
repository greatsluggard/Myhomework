using MyLibrary1;
using System.IO;
using System.Text;

namespace Task2
{
    class Task2
    {
        static void Main ()
        {
            string path = @"C:\Example.txt";
            string text = File.ReadAllText(path);
            int[] array = text
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n))
            .ToArray();
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine ("Наиболее частый элемент - " +Sort.SortOfCountingAndFindFrequent(array));
        }
    }
}
