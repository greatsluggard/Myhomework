namespace MyLibrary1
{
    public class Sort
    {
        static public int SortOfCounting(int[] array, int minValue, int maxValue, int frequent)
        {// ниже использую алгоритм сортировки подсчётом
            int temp = 0; // временная переменная, которая принимает количество раз наиболее частого элемента
            int j = 0;
            int[] count = new int[maxValue + 1];
            for (int i = minValue; i <= maxValue; i++)
            {
                count[i] = 0;
            }
            for (int i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
                if (count[array[i]] > temp) // этот if ключевая часть кода позволяющая получить...
                {                           //...самый частовстречающийся элемент
                    temp = count[array[i]];
                    frequent = array[i];
                }
            }
            for (int i = minValue; i <= maxValue; i++)
            {
                while (count[i] > 0)
                {
                    array[j] = i;
                    j++;
                    count[i]--;
                }
            }
            return frequent;
        }
    }
}