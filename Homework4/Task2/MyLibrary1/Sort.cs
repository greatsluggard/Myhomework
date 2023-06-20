namespace MyLibrary1
{
    public class Sort
    {
        static public int SortOfCountingAndFindFrequent(int[] array)
        {// ниже использую алгоритм сортировки подсчётом

            //для того чтобы убрать лишние параметры введём начальный цикл...
            //...определяющий минимальный и максимальный элементы массива
            int minValue = int.MaxValue;
            int maxValue = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            int frequent = 0;
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